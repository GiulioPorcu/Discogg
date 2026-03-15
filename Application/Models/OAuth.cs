using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents OAuth authentication metadata returned by the API,
    /// including user information and consumer details.
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// Gets or sets the OAuth record identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the username associated with the OAuth token.
        /// </summary>
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for this OAuth entry.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the OAuth consumer application.
        /// </summary>
        [JsonPropertyName("consumer_name")]
        public string? ConsumerName { get; set; }

        /// <summary>
        /// Gets or sets the OAuth token used for authentication.
        /// This value is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore]
        public string? Token { get; set; }
    }
}