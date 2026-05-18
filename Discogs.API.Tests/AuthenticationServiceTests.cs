using Discogs.API.Core;
using Discogs.API.Services;
using Discogs.API.Tests.Networking;
using System.Net;
using System.Text.Json;

namespace Discogs.API.Tests
{
    [TestClass]
    public sealed class AuthenticationServiceTests
    {
        [TestMethod]
        public async Task AuthenticateAsync_WithEmptyToken_ReturnsNullAndRaisesError()
        {
            using FakeResponseHandler handler = new();
            using HttpClient client = new(handler);
            DiscogsService discogsService = new(client);
            SerializationService serializationService = new();
            AuthenticationService authService = new(discogsService, serializationService);

            OAuth? result = await authService.AuthenticateAsync("", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_WithValidToken_ReturnsUser()
        {
            string oauthJson = JsonSerializer.Serialize(new OAuth { Id = 123, UserName = "testuser" });
            using FakeResponseHandler handler = new(oauthJson, HttpStatusCode.OK);
            using HttpClient client = new(handler);
            DiscogsService discogsService = new(client);
            SerializationService serializationService = new();
            AuthenticationService authService = new(discogsService, serializationService);

            OAuth? result = await authService.AuthenticateAsync("valid-token", CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("testuser", result!.UserName);
            Assert.IsTrue(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_WithInvalidToken_ReturnsNull()
        {
            using FakeResponseHandler handler = new("Invalid token", HttpStatusCode.Unauthorized);
            using HttpClient client = new(handler);
            DiscogsService discogsService = new(client);
            SerializationService serializationService = new();
            AuthenticationService authService = new(discogsService, serializationService);

            OAuth? result = await authService.AuthenticateAsync("invalid-token", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }

        [TestMethod]
        public async Task AuthenticateAsync_OnNetworkError_ReturnsNull()
        {
            using ThrowingHttpMessageHandler handler = new();
            using HttpClient client = new(handler);
            DiscogsService discogsService = new(client);
            SerializationService serializationService = new();
            AuthenticationService authService = new(discogsService, serializationService);

            OAuth? result = await authService.AuthenticateAsync("test-token", CancellationToken.None);

            Assert.IsNull(result);
            Assert.IsFalse(authService.IsAuthenticated);
        }
    }
}