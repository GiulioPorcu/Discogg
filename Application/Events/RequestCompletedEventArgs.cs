using System.Net;

namespace Application.Events
{
    public class RequestCompletedEventArgs : EventArgs
    {
        public HttpMethod Method { get; set; }
        public Uri Uri { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public RequestCompletedEventArgs(HttpMethod method, Uri uri, HttpStatusCode statusCode)
        {
            this.Method = method;
            this.Uri = uri;
            this.StatusCode = statusCode;
        }
    }
}
