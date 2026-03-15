using Application.Models;
using Application.Properties;

namespace Application.Services
{
    /// <summary>
    /// Provides access to Discogs user information, including retrieval of user profiles
    /// and error reporting when requests or deserialization fail.
    /// </summary>
    /// <param name="discogsService">
    /// The service responsible for performing HTTP requests to the Discogs API.
    /// </param>
    /// <param name="serializationService">
    /// The service used to deserialize JSON responses returned by the API.
    /// </param>
    public class UserService(DiscogsService discogsService, SerializationService serializationService)
    {
        /// <summary>
        /// Occurs when an error is raised during user retrieval.
        /// The event argument contains a descriptive error message.
        /// </summary>
        public event EventHandler<string>? OnError;

        /// <summary>
        /// The underlying Discogs service used to perform HTTP requests.
        /// </summary>
        private readonly DiscogsService _discogsService = discogsService;

        /// <summary>
        /// The serialization service used to deserialize JSON responses.
        /// </summary>
        private readonly SerializationService _serializationService = serializationService;

        /// <summary>
        /// Retrieves a Discogs user profile by username.
        /// Sends a GET request to the Discogs API and deserializes the response
        /// into a <see cref="User"/> model if successful.
        /// </summary>
        /// <param name="name">The username of the Discogs user to retrieve.</param>
        /// <param name="ct">A cancellation token used to cancel the request.</param>
        /// <returns>
        /// A <see cref="User"/> instance if the request and deserialization succeed;
        /// otherwise <c>null</c>.
        /// </returns>
        public async Task<User?> GetAsync(string name, CancellationToken ct = default)
        {
            try
            {
                string uri = DiscogsService.AssembleUri($"/users/{name}");

                using HttpResponseMessage response = await this._discogsService
                    .DoRequestAsync(HttpMethod.Get, uri, content: null, ct)
                    ?? throw new Exception(Messages.WebRequestFailed);

                return response.IsSuccessStatusCode &&
                       await this._serializationService.DeserializeAsync<User>(response, ct) is User user
                    ? user
                    : null;
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return null;
            }
        }
    }
}
