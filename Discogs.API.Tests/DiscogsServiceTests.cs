using Discogs.API.Services;
using Discogs.API.Tests.Networking;
using System.Net;

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
            Dictionary<string, string> queryParams = new()
            {
                { "page", "1" },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            Assert.Contains("page=1", result);
            Assert.Contains("per_page=25", result);
        }

        [TestMethod]
        public void AssembleUri_WithNullValueQueryParam_ExcludesParam()
        {
            Dictionary<string, string> queryParams = new()
            {
                { "page", null! },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            Assert.Contains("per_page=25", result);
        }

        [TestMethod]
        public void AssembleUri_WithWhitespaceValueQueryParam_ExcludesParam()
        {
            Dictionary<string, string> queryParams = new()
            {
                { "page", "   " },
                { "per_page", "25" }
            };

            string result = DiscogsService.AssembleUri("/database/search", queryParams);

            Assert.Contains("per_page=25", result);
        }
    }

    [TestClass]
    public sealed class DiscogsServiceRetryTests
    {
        [TestMethod]
        public async Task DoRequestAsync_OnSuccess_ReturnsResponse()
        {
            using MockHttpMessageHandler handler = new(HttpStatusCode.OK);
            using HttpClient client = new(handler);
            DiscogsService service = new(client);

            HttpResponseMessage? response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response!.StatusCode);
        }

        [TestMethod]
        public async Task DoRequestAsync_OnServerError_RetriesAndReturnsNull()
        {
            using MockHttpMessageHandler handler = new(HttpStatusCode.InternalServerError);
            using HttpClient client = new(handler);
            DiscogsService service = new(client);

            HttpResponseMessage? response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNull(response);
            Assert.AreEqual(3, handler.CallCount);
        }

        [TestMethod]
        public async Task DoRequestAsync_OnRateLimit_RetriesMultipleTimes()
        {
            using MockHttpMessageHandler handler = new((HttpStatusCode)429);
            using HttpClient client = new(handler);
            DiscogsService service = new(client);

            HttpResponseMessage? response = await service.DoRequestAsync(HttpMethod.Get, "https://api.discogs.com/test", null, CancellationToken.None);

            Assert.IsNull(response);
            Assert.AreEqual(3, handler.CallCount);
        }
    }
}