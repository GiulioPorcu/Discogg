using System.Net;

namespace Application.Events
{
    public class RequestCompletedEventArgs(HttpMethod? method, Uri? uri, HttpStatusCode? statusCode) : EventArgs
    {
        public HttpMethod? Method { get; } = method;
        public Uri? Uri { get; } = uri;
        public HttpStatusCode? StatusCode { get; } = statusCode;
    }
}