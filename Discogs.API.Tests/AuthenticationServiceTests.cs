using System.Net;
using System.Text.Json;
using Application.Services;
using Discogs.API;

namespace Discogs.API.Tests
{
    [TestClass]
    public sealed class AuthenticationServiceTests
    {
        [TestMethod]
        public async Task AuthenticateAsync_WithEmptyToken_ReturnsNullAndRaisesError()
        {
            using var handler = new FakeResponseHandler();
            using var client = new HttpClient(handler);
            var discogsService = new DiscogsService(client);
            var serializationService = new SerializationService();
            var authService = new AuthenticationService(discogsService, serializationService);

            var result = await authService.AuthenticateAsync("", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_WithValidToken_ReturnsUser()
        {
            string oauthJson = JsonSerializer.Serialize(new OAuth { Id = 123, UserName = "testuser" });
            using var handler = new FakeResponseHandler(oauthJson, HttpStatusCode.OK);
            using var client = new HttpClient(handler);
            var discogsService = new DiscogsService(client);
            var serializationService = new SerializationService();
            var authService = new AuthenticationService(discogsService, serializationService);

            var result = await authService.AuthenticateAsync("valid-token", CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("testuser", result!.UserName);
            Assert.IsTrue(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_WithInvalidToken_ReturnsNull()
        {
            using var handler = new FakeResponseHandler("Invalid token", HttpStatusCode.Unauthorized);
            using var client = new HttpClient(handler);
            var discogsService = new DiscogsService(client);
            var serializationService = new SerializationService();
            var authService = new AuthenticationService(discogsService, serializationService);

            var result = await authService.AuthenticateAsync("invalid-token", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_OnNetworkError_ReturnsNull()
        {
            using var handler = new ThrowingHttpMessageHandler();
            using var client = new HttpClient(handler);
            var discogsService = new DiscogsService(client);
            var serializationService = new SerializationService();
            var authService = new AuthenticationService(discogsService, serializationService);

            var result = await authService.AuthenticateAsync("test-token", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }
    }

    internal sealed class FakeResponseHandler : HttpMessageHandler
    {
        private readonly string _responseBody;
        private readonly HttpStatusCode _statusCode;

        public FakeResponseHandler(string responseBody = "{}", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _responseBody = responseBody;
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_responseBody)
            };
            return Task.FromResult(response);
        }
    }

    internal sealed class ThrowingHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new HttpRequestException("Network error");
        }
    }
}