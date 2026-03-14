using Application.Events;
using Application.Models;
using Application.Services;
using System.Text.Json;

namespace Application.Clients
{
    public class DiscogsClient
    {
        private const string ROOT = "https://api.discogs.com";

        private readonly HttpClient _client;

        public event EventHandler<string>? OnError;

        public event EventHandler<RequestStartingEventArgs>? OnRequestStarting;
        public event EventHandler<RequestCompletedEventArgs>? OnRequestCompleted;

        public event EventHandler<ConnectivityChangeEventArgs>? OnConnectivityChanged;
        public event EventHandler<AuthenticationChangedEventArgs>? OnAuthenticationChanged;

        public ApiInfo? Info { get; private set; }
        public User? User { get; private set; }

        public bool IsConnected => !String.IsNullOrWhiteSpace(this.Info?.ApiVersion);
        public bool IsAuthenticated => this.User?.Id != null;

        public DiscogsClient(HttpClient client, LoadingService loadingService)
        {
            this._client = client;

            this.OnRequestStarting += (sender, args) => loadingService.Start();
            this.OnRequestCompleted += (sender, args) => loadingService.Stop();
        }

        private string AssembleUri(string? route, Dictionary<string, string>? queryParams = null)
        {
            if (String.IsNullOrWhiteSpace(route))
            {
                return ROOT;
            }

            UriBuilder uriBuilder = new($"{ROOT}/{route}");

            if (queryParams is null || queryParams.Count <= 0)
            {
                return uriBuilder.Uri.ToString();
            }

            if (this.IsAuthenticated)
            {
                queryParams["token"] = this.User!.Token!;
            }

            string query = String.Join("&", queryParams
                .Where(pair => !String.IsNullOrWhiteSpace(pair.Value))
                .Select(pair => $"{pair.Key}={Uri.EscapeDataString(pair.Value!)}"));

            uriBuilder.Query = query;
            return uriBuilder.Uri.ToString();
        }

        public async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, string uriString, HttpContent? content, CancellationToken ct)
            => await this.DoRequestAsync(method, new Uri(uriString), content, ct);

        public async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, Uri uri, HttpContent? content, CancellationToken ct)
        {
            this.OnRequestStarting?.Invoke(this, new RequestStartingEventArgs(method, uri));

            HttpRequestMessage request = new(method, uri) { Content = content };
            HttpResponseMessage response = await this._client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            this.OnRequestCompleted?.Invoke(this, new RequestCompletedEventArgs(method, uri, response.StatusCode));
            return response;
        }

        public async Task<T?> DeserializeAsync<T>(HttpResponseMessage responseMessage, CancellationToken ct)
        {
            try
            {
                using Stream stream = await responseMessage.Content.ReadAsStreamAsync(ct);
                return await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: ct);
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return default;
            }
        }

        public async Task<bool> ConnectAsync(CancellationToken ct = default)
        {
            this.Info = null;
            this.OnConnectivityChanged?.Invoke(this, new ConnectivityChangeEventArgs(null));

            try
            {
                using HttpResponseMessage responseMessage = await this.DoRequestAsync(HttpMethod.Get, DiscogsClient.ROOT, content: null, ct);

                if (responseMessage.IsSuccessStatusCode && await this.DeserializeAsync<ApiInfo>(responseMessage, ct) is ApiInfo info)
                {
                    this.Info = info;
                    this.OnConnectivityChanged?.Invoke(this, new ConnectivityChangeEventArgs(info));

                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return false;
            }
        }

        public async Task<bool> AuthenticateAsync(string token, CancellationToken ct = default)
        {
            this.User = null;
            this.OnAuthenticationChanged?.Invoke(this, new AuthenticationChangedEventArgs(null));

            try
            {
                string uri = this.AssembleUri("/oauth/identity");

                using HttpResponseMessage identityResponse = await this.DoRequestAsync(HttpMethod.Get, uri, content: null, ct);

                if (identityResponse.IsSuccessStatusCode && await this.DeserializeAsync<User>(identityResponse, ct) is User user)
                {
                    using HttpResponseMessage detailResponse = await this.DoRequestAsync(HttpMethod.Get, user.ResourceUrl!, content: null, ct);

                    if (detailResponse.IsSuccessStatusCode && await this.DeserializeAsync<UserDetails>(detailResponse, ct) is UserDetails details)
                    {
                        this.User = user;
                        this.User.Token = token;
                        this.User.Details = details;

                        this.OnAuthenticationChanged?.Invoke(this, new AuthenticationChangedEventArgs(this.User));
                        return true;
                    }
                }

                return false;

            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return false;
            }
        }
    }
}