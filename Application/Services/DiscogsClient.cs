using System.Net;

namespace Application.Services
{
    public class DiscogsClient(HttpClient client)
    {
        private const string ROOT = "https://api.discogs.com";
        private const string TEST_URI = $"{ROOT}/marketplace/price_suggestions/0?token=";

        public string Token { get; set; } = string.Empty;
        public bool IsAuthenticated { get; private set; } = false;

        public async Task<bool> Authenticate()
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, TEST_URI + this.Token))
            {
                using (HttpResponseMessage responseMessage = await client.SendAsync(requestMessage))
                {
                    this.IsAuthenticated = responseMessage.StatusCode != HttpStatusCode.Unauthorized;
                    return this.IsAuthenticated;
                }
            }
        }
    }
}