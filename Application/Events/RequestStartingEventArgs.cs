namespace Application.Events
{
    /// <summary>
    /// Provides data for an HTTP request that is starting.
    /// </summary>
    /// <param name="method">
    /// The HTTP method used for the request.
    /// </param>
    /// <param name="uri">
    /// The request URI.
    /// </param>
    public class RequestStartingEventArgs(HttpMethod? method, Uri? uri) : EventArgs
    {
        /// <summary>
        /// Gets the HTTP method used for the request.
        /// </summary>
        public HttpMethod? Method { get; } = method;

        /// <summary>
        /// Gets the request URI.
        /// </summary>
        public Uri? Uri { get; } = uri;
    }
}