using Application.Models;
using Application.Properties;

namespace Application.Services
{
    public class UserService(DiscogsService discogsService, SerializationService serializationService)
    {
        public event EventHandler<string>? OnError;

        private readonly DiscogsService _discogsService = discogsService;
        private readonly SerializationService _serializationService = serializationService;

        public async Task<User?> GetAsync(string name, CancellationToken ct = default)
        {
            try
            {
                string uri = DiscogsService.AssembleUri($"/users/{name}");

                using HttpResponseMessage response = await this._discogsService.DoRequestAsync(HttpMethod.Get, uri, content: null, ct) ?? throw new Exception(Messages.WebRequestFailed);
                return response.IsSuccessStatusCode && await this._serializationService.DeserializeAsync<User>(response, ct) is User user ? user : null;
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return null;
            }
        }
    }
}
