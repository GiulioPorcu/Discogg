using System.Net;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Discogs.API.Tests
{
    [TestClass]
    public sealed class DiscogsServiceTests
    {
        [TestMethod]
        public void AssembleUri_WithNoQueryParams_ReturnsBaseUri()
        {
            string result = DiscogsService.AssembleUri("/users/test");
            Assert.AreEqual("https://api.discogs.com/users/test", result);
        }

        [TestMethod]
        public void AssembleUri_WithQueryParams_AppendsQueryString()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "page", "1" },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            StringAssert.Contains(result, "page=1");
            StringAssert.Contains(result, "per_page=25");
        }

        [TestMethod]
        public void AssembleUri_WithNullValueQueryParam_ExcludesParam()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "page", null! },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            StringAssert.Contains(result, "per_page=25");
        }

        [TestMethod]
        public void AssembleUri_WithWhitespaceValueQueryParam_ExcludesParam()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "page", "   " },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            StringAssert.Contains(result, "per_page=25");
        }
    }

    [TestClass]
    public sealed class DiscogsServiceRetryTests
    {
        [TestMethod]
        public async Task DoRequestAsync_OnSuccess_ReturnsResponse()
        {
            using var handler = new MockHttpMessageHandler(HttpStatusCode.OK);
            using var client = new HttpClient(handler);
            var service = new DiscogsService(client);

            var response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response!.StatusCode);
        }

        [TestMethod]
        public async Task DoRequestAsync_OnServerError_RetriesAndReturnsNull()
        {
            using var handler = new MockHttpMessageHandler(HttpStatusCode.InternalServerError);
            using var client = new HttpClient(handler);
            var service = new DiscogsService(client);

            var response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNull(response);
            Assert.AreEqual(3, handler.CallCount);
        }

        [TestMethod]
        public async Task DoRequestAsync_OnRateLimit_RetriesMultipleTimes()
        {
            using var handler = new MockHttpMessageHandler((HttpStatusCode)429);
            using var client = new HttpClient(handler);
            var service = new DiscogsService(client);

            var response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNull(response);
            Assert.AreEqual(3, handler.CallCount);
        }
    }

    internal sealed class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;
        public int CallCount { get; private set; }

        public MockHttpMessageHandler(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CallCount++;
            var response = new HttpResponseMessage(_statusCode);
            return Task.FromResult(response);
        }
    }
}