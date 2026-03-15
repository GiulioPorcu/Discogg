using System.Net;

namespace Application.Events
{
    /// <summary>
    /// Provides data for a completed HTTP request.
    /// </summary>
    /// <param name="method">
    /// The HTTP method used for the request.
    /// </param>
    /// <param name="uri">
    /// The request URI.
    /// </param>
    /// <param name="statusCode">
    /// The resulting HTTP status code.
    /// </param>
    public class RequestCompletedEventArgs(HttpMethod? method, Uri? uri, HttpStatusCode? statusCode) : EventArgs
    {
        /// <summary>
        /// Gets the HTTP method used for the request.
        /// </summary>
        public HttpMethod? Method { get; } = method;

        /// <summary>
        /// Gets the request URI.
        /// </summary>
        public Uri? Uri { get; } = uri;

        /// <summary>
        /// Gets the HTTP status code returned by the request.
        /// </summary>
        public HttpStatusCode? StatusCode { get; } = statusCode;
    }
}