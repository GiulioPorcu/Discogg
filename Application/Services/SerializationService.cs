using System.Text.Json;

namespace Application.Services
{
    public class SerializationService
    {
        public event EventHandler<string>? OnError;

        public async Task<T?> DeserializeAsync<T>(HttpResponseMessage responseMessage, CancellationToken ct)
        {
            try
            {
                using Stream stream = await responseMessage.Content.ReadAsStreamAsync(ct);
                return await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: ct);
            }
            catch (Exception exception)
            {
                this.OnError?.Invoke(this, exception.Message);
                return default;
            }
        }
    }
}