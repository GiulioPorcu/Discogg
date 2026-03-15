using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents a contributor associated with a release entry.
    /// </summary>
    public class Contributor
    {
        /// <summary>
        /// Gets or sets the contributor's username.
        /// </summary>
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the contributor.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }
    }
}
