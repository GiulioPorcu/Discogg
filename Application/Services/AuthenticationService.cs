using Application.Events;
using Application.Models;
using Application.Properties;

namespace Application.Services
{
    public class AuthenticationService(DiscogsService discogsService, SerializationService serializationService)
    {
        public event EventHandler<string>? OnError;
        public event EventHandler<AuthenticationChangedEventArgs>? OnAuthenticationChanged;

        public OAuth? User { get; private set; }
        public bool IsAuthenticated => this.User?.Id != null;

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