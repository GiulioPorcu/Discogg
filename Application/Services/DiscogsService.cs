using Application.Events;

namespace Application.Services
{
    /// <summary>
    /// Provides low‑level HTTP request handling for communicating with the Discogs API,
    /// including URI construction, request execution, and request lifecycle events.
    /// </summary>
    /// <param name="client">
    /// The <see cref="HttpClient"/> instance used to send HTTP requests.
    /// </param>
    public class DiscogsService(HttpClient client)
    {
        /// <summary>
        /// The base URI for all Discogs API endpoints.
        /// </summary>
        public const string BASE_URI = "https://api.discogs.com";

        /// <summary>
        /// Occurs when an error is raised during request processing.
        /// The event argument contains a descriptive error message.
        /// </summary>
        public event EventHandler<string>? OnError;

        /// <summary>
        /// Occurs immediately before an HTTP request is sent.
        /// Provides information about the HTTP method and target URI.
        /// </summary>
        public event EventHandler<RequestStartingEventArgs>? OnRequestStarting;

        /// <summary>
        /// Occurs after an HTTP request completes.
        /// Provides information about the HTTP method, target URI, and response status code.
        /// </summary>
        public event EventHandler<RequestCompletedEventArgs>? OnRequestCompleted;

        /// <summary>
        /// The underlying <see cref="HttpClient"/> used to perform HTTP requests.
        /// </summary>
        private readonly HttpClient _client = client;

        /// <summary>
        /// Assembles a fully qualified Discogs API URI using the specified route
        /// and optional query parameters.
        /// </summary>
        /// <param name="route">The API route to append to the base URI.</param>
        /// <param name="queryParams">Optional query parameters to include in the URI.</param>
        /// <returns>A complete request URI as a string.</returns>
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

        /// <summary>
        /// Sends an HTTP request to the specified URI using the given method and content.
        /// Raises lifecycle events before and after the request, and reports errors when they occur.
        /// </summary>
        /// <param name="method">The HTTP method to use for the request.</param>
        /// <param name="uriString">The target URI as a string.</param>
        /// <param name="content">Optional HTTP content to include in the request.</param>
        /// <param name="ct">A cancellation token used to cancel the request.</param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/> returned by the server,
        /// or <c>null</c> if an error occurred.
        /// </returns>

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