using System.Text.Json;

namespace Application.Services
{
    /// <summary>
    /// Provides JSON deserialization functionality for HTTP responses,
    /// including error reporting when deserialization fails.
    /// </summary>
    public class SerializationService
    {
        /// <summary>
        /// Occurs when an error is raised during deserialization.
        /// The event argument contains a descriptive error message.
        /// </summary>
        public event EventHandler<string>? OnError;

        /// <summary>
        /// Deserializes the content of an <see cref="HttpResponseMessage"/> into the specified type.
        /// If deserialization fails, an error event is raised and <c>null</c> is returned.
        /// </summary>
        /// <typeparam name="T">The target type to deserialize into.</typeparam>
        /// <param name="responseMessage">The HTTP response containing the JSON payload.</param>
        /// <param name="ct">A cancellation token used to cancel the operation.</param>
        /// <returns>
        /// An instance of <typeparamref name="T"/> if deserialization succeeds;
        /// otherwise <c>null</c>.
        /// </returns>
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