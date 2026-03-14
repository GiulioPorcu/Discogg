namespace Application.Events
{
    public class RequestStartingEventArgs(HttpMethod? method, Uri? uri) : EventArgs
    {
        public HttpMethod? Method { get; } = method;
        public Uri? Uri { get; } = uri;
    }
}