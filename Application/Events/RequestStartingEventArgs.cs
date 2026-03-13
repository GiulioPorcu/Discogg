namespace Application.Events
{
    public class RequestStartingEventArgs : EventArgs
    {
        public HttpMethod Method { get; set; }
        public Uri Uri { get; set; }

        public RequestStartingEventArgs(HttpMethod method, Uri uri)
        {

            this.Method = method;
            this.Uri = uri;
        }
    }
}
