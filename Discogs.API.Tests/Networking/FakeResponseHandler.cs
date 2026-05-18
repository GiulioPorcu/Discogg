using System.Net;

namespace Discogs.API.Tests.Networking
{
    internal sealed class FakeResponseHandler(string responseBody = "{}", HttpStatusCode statusCode = HttpStatusCode.OK) : HttpMessageHandler
    {
        private readonly string _responseBody = responseBody;
        private readonly HttpStatusCode _statusCode = statusCode;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new(this._statusCode)
            {
                Content = new StringContent(this._responseBody)
            };

            return Task.FromResult(response);
        }
    }
}
