using System.Net;

namespace Application.Events
{
    public class RequestCompletedEventArgs(HttpMethod method, Uri uri, HttpStatusCode statusCode) : EventArgs
    {
        public HttpMethod Method { get; set; } = method;
        public Uri Uri { get; set; } = uri;
        public HttpStatusCode StatusCode { get; set; } = statusCode;
    }
}