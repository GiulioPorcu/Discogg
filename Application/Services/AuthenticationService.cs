using Application.Events;
using Application.Models;
using Application.Properties;

namespace Application.Services
{
    /// <summary>
    /// Provides authentication functionality for validating Discogs API tokens,
    /// retrieving the associated user identity, and managing authentication state.
    /// </summary>
    /// <param name="discogsService">
    /// The service used to perform authenticated Discogs API requests.
    /// </param>
    /// <param name="serializationService">
    /// The service responsible for deserializing API responses.
    /// </param>
    public class AuthenticationService(DiscogsService discogsService, SerializationService serializationService)
    {
        /// <summary>
        /// Occurs when an authentication-related error is raised.
        /// The event argument contains a descriptive error message.
        /// </summary>
        public event EventHandler<string>? OnError;

        /// <summary>
        /// Occurs when the authentication state changes, such as after a successful
        /// login, logout, or failed authentication attempt.
        /// </summary>
        public event EventHandler<AuthenticationChangedEventArgs>? OnAuthenticationChanged;

        /// <summary>
        /// Gets the authenticated user information returned by the Discogs API,
        /// or <c>null</c> if no user is currently authenticated.
        /// </summary>
        public OAuth? User { get; private set; }

        /// <summary>
        /// Gets a value indicating whether a user is currently authenticated.
        /// </summary>
        public bool IsAuthenticated => this.User?.Id != null;

        /// <summary>
        /// Attempts to authenticate using the provided API token. If successful,
        /// retrieves the associated user identity from the Discogs API and updates
        /// the authentication state. Errors and state changes are surfaced through events.
        /// </summary>
        /// <param name="token">The Discogs API token to authenticate with.</param>
        /// <param name="ct">A cancellation token used to cancel the request.</param>
        /// <returns>
        /// The authenticated <see cref="OAuth"/> user object if authentication succeeds;
        /// otherwise <c>null</c>.
        /// </returns>

        public async Task<OAuth?> AuthenticateAsync(string token, CancellationToken ct = default)
        {
            this.User = null;
            this.OnAuthenticationChanged?.Invoke(this, new AuthenticationChangedEventArgs(null));

            if (String.IsNullOrWhiteSpace(token))
            {
                this.OnError?.Invoke(this, Messages.InvalidApiToken);
            }
            else
            {
                try
                {
                    string uri = DiscogsService.AssembleUri("/oauth/identity", new Dictionary<string, string>() { { "token", token } });
                    using HttpResponseMessage? response = await discogsService.DoRequestAsync(HttpMethod.Get, uri, content: null, ct) ?? throw new Exception(Messages.WebRequestFailed);

                    if (response.IsSuccessStatusCode && await serializationService.DeserializeAsync<OAuth>(response, ct) is OAuth user)
                    {
                        user.Token = token;
                        this.User = user;
                        this.OnAuthenticationChanged?.Invoke(this, new AuthenticationChangedEventArgs(this.User));
                    }
                    else
                    {
                        this.OnError?.Invoke(this, await response.Content.ReadAsStringAsync(ct));
                    }
                }
                catch (Exception exception)
                {
                    this.OnError?.Invoke(this, exception.Message);
                }
            }

            return this.User;
        }
    }
}