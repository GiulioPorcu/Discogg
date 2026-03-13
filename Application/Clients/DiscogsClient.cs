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

        public Identity? User { get; private set; }
        public bool IsAuthenticated { get { return this.User?.Id != null; } }

        public DiscogsClient(HttpClient client, LoadingService loadingService)
        {
            this._client = client;

            OnRequestStarting += (_, _) => loadingService.Start();
            OnRequestCompleted += (_, _) => loadingService.Stop();
        }

        private async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, string route, Dictionary<string, string>? queryParams = null, CancellationToken ct = default)
        {
            UriBuilder builder = new UriBuilder($"{ROOT}/{route}");

            if (queryParams is not null)
            {
                if (this.IsAuthenticated)
                {
                    queryParams["token"] = this.User!.Token!;
                }

                string query = string.Join("&",
                    queryParams.Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value)).Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value!)}")
                );

                builder.Query = query;
            }

            Uri uri = builder.Uri;

            this.OnRequestStarting?.Invoke(this, new RequestStartingEventArgs(method, uri));

            await Task.Delay(1000, ct);

            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            HttpResponseMessage response = await this._client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            this.OnRequestCompleted?.Invoke(this, new RequestCompletedEventArgs(method, uri, response.StatusCode));

            return response;
        }

        public async Task<bool> AuthenticateAsync(string token, CancellationToken ct = default)
        {
            try
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>()
                {
                    {"token", token }
                };

                using (HttpResponseMessage response = await this.DoRequestAsync(HttpMethod.Get, "/oauth/identity", queryParams, ct))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        this.User = null;
                        return false;
                    }

                    using (Stream stream = await response.Content.ReadAsStreamAsync(ct))
                    {

                        Identity? identity = await JsonSerializer.DeserializeAsync<Identity>(stream, cancellationToken: ct);

                        if (identity is null)
                        {
                            this.User = null;
                            return false;
                        }

                        identity.Token = token;
                        this.User = identity;

                        return true;
                    }
                }
            }
            catch (Exception exception)
            {
                OnError?.Invoke(this, exception.ToString());
                this.User = null;
                return false;
            }
        }
    }
}