namespace Application.Events
{
    public class RequestStartingEventArgs(HttpMethod method, Uri uri) : EventArgs
    {
        public HttpMethod Method { get; set; } = method;
        public Uri Uri { get; set; } = uri;
    }
}