using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents the user who originally submitted the release entry.
    /// </summary>
    public class Submitter
    {
        /// <summary>
        /// Gets or sets the submitter's username.
        /// </summary>
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the submitter.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }
    }
}
