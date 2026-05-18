using System.Net;

namespace Discogs.API.Tests.Networking
{
    internal sealed class MockHttpMessageHandler(HttpStatusCode statusCode) : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode = statusCode;
        public int CallCount { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.CallCount++;
            HttpResponseMessage response = new(this._statusCode);
            return Task.FromResult(response);
        }
    }
}
