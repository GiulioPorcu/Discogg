using Application.Events;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    /// <summary>
    /// Provides low‑level HTTP request handling for communicating with the Discogs API,
    /// including URI construction, request execution, and request lifecycle events.
    /// </summary>
    /// <param name="client">
    /// The <see cref="HttpClient"/> instance used to send HTTP requests.
    /// </param>
    /// <param name="logger">
    /// The <see cref="ILogger{TCategoryName}"/> instance used for logging.
    /// </param>
    public class DiscogsService(HttpClient client, ILogger<DiscogsService>? logger = null)
    {
        /// <summary>
        /// The base URI for all Discogs API endpoints.
        /// </summary>
        public const string BASE_URI = "https://api.discogs.com";

        private const int MAX_RETRIES = 3;
        private const int INITIAL_DELAY_MS = 1000;

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

        private readonly HttpClient _client = client;
        private readonly ILogger<DiscogsService>? _logger = logger;

        /// <summary>
        /// Assembles a fully qualified Discogs API URI using the specified route
        /// and optional query parameters.
        /// </summary>
        /// <param name="route">The API route to append to the base URI.</param>
        /// <param name="queryParams">Optional query parameters to include in the URI.</param>
        /// <returns>A complete request URI as a string.</returns>
        public static string AssembleUri(string? route, Dictionary<string, string>? queryParams = null)
        {
            UriBuilder uriBuilder = new($"{BASE_URI}{route ?? string.Empty}");

            if (queryParams is null || queryParams.Count <= 0)
            {
                return uriBuilder.Uri.ToString();
            }

            string query = string.Join("&", queryParams
                .Where(pair => !string.IsNullOrWhiteSpace(pair.Value))
                .Select(pair => $"{pair.Key}={Uri.EscapeDataString(pair.Value!)}"));

            uriBuilder.Query = query;
            return uriBuilder.Uri.ToString();
        }

        /// <summary>
        /// Determines whether the HTTP response indicates a transient error
        /// that may succeed on retry.
        /// </summary>
        private static bool IsTransientError(HttpResponseMessage response) => response.StatusCode switch
        {
            System.Net.HttpStatusCode.ServiceUnavailable => true,
            System.Net.HttpStatusCode.TooManyRequests => true,
            System.Net.HttpStatusCode.GatewayTimeout => true,
            System.Net.HttpStatusCode.BadGateway => true,
            _ => (int)response.StatusCode >= 500
        };

        /// <summary>
        /// Sends an HTTP request to the specified URI using the given method and content,
        /// with automatic retry logic for transient errors.
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
            Uri uri = new(uriString);
            this.OnRequestStarting?.Invoke(null, new RequestStartingEventArgs(method, uri));

            Exception? lastException = null;
            for (int attempt = 0; attempt < MAX_RETRIES; attempt++)
            {
                try
                {
                    HttpRequestMessage request = new(method, uri) { Content = content };
                    HttpResponseMessage response = await this._client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

                    this.OnRequestCompleted?.Invoke(null, new RequestCompletedEventArgs(method, uri, response.StatusCode));

                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }

                    if (!IsTransientError(response))
                    {
                        this._logger?.LogWarning("Non-retryable error: {StatusCode}", response.StatusCode);
                        return response;
                    }

                    this._logger?.LogWarning("Transient error {StatusCode}, attempt {Attempt}/{MaxRetries}",
                        response.StatusCode, attempt + 1, MAX_RETRIES);

                    response.Dispose();
                    await Task.Delay(INITIAL_DELAY_MS * (int)Math.Pow(2, attempt), ct);
                }
                catch (Exception exception) when (attempt < MAX_RETRIES - 1)
                {
                    lastException = exception;
                    this._logger?.LogWarning(exception, "Request failed, attempt {Attempt}/{MaxRetries}", attempt + 1, MAX_RETRIES);
                    await Task.Delay(INITIAL_DELAY_MS * (int)Math.Pow(2, attempt), ct);
                }
                catch (Exception exception)
                {
                    lastException = exception;
                    this._logger?.LogError(exception, "Request failed after {MaxRetries} attempts", MAX_RETRIES);
                }
            }

            string errorMessage = lastException?.Message ?? "Unknown error after retries";
            this.OnError?.Invoke(this, errorMessage);
            return null;
        }

        /// <summary>
        /// Sends a GET request to the specified URI.
        /// </summary>
        public async Task<HttpResponseMessage?> DoGetRequestAsync(string uriString, CancellationToken ct = default)
            => await this.DoRequestAsync(HttpMethod.Get, uriString, content: null, ct);
    }
}