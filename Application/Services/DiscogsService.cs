using Application.Events;

namespace Application.Services
{
    public class DiscogsService(HttpClient client)
    {
        public const string BASE_URI = "https://api.discogs.com";

        public event EventHandler<string>? OnError;
        public event EventHandler<RequestStartingEventArgs>? OnRequestStarting;
        public event EventHandler<RequestCompletedEventArgs>? OnRequestCompleted;

        private readonly HttpClient _client = client;

        public static string AssembleUri(string? route, Dictionary<string, string>? queryParams = null)
        {
            UriBuilder uriBuilder = new($"{BASE_URI}{route ?? String.Empty}");

            if (queryParams is null || queryParams.Count <= 0)
            {
                return uriBuilder.Uri.ToString();
            }

            string query = String.Join("&", queryParams
                .Where(pair => !String.IsNullOrWhiteSpace(pair.Value))
                .Select(pair => $"{pair.Key}={Uri.EscapeDataString(pair.Value!)}"));

            uriBuilder.Query = query;
            return uriBuilder.Uri.ToString();
        }

        public async Task<HttpResponseMessage?> DoRequestAsync(HttpMethod method, string uriString, HttpContent? content, CancellationToken ct)
        {
            try
            {
                Uri uri = new(uriString);
                this.OnRequestStarting?.Invoke(null, new RequestStartingEventArgs(method, uri));

                HttpRequestMessage request = new(method, uri) { Content = content };
                HttpResponseMessage response = await this._client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

                this.OnRequestCompleted?.Invoke(null, new RequestCompletedEventArgs(method, uri, response.StatusCode));
                return response;
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return null;
            }
        }
    }
}