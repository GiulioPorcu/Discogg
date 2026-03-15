using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents an artist entry returned by the API.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Gets or sets the artist's display name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the artist's alternative name variation.
        /// </summary>
        [JsonPropertyName("anv")]
        public string? AlternativeNameVariation { get; set; }

        /// <summary>
        /// Gets or sets the join phrase used when multiple artists are listed together.
        /// </summary>
        [JsonPropertyName("join")]
        public string? JoinPhrase { get; set; }

        /// <summary>
        /// Gets or sets the artist's role or contribution.
        /// </summary>
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets the track numbers associated with the artist.
        /// </summary>
        [JsonPropertyName("tracks")]
        public string? Tracks { get; set; }

        /// <summary>
        /// Gets or sets the artist's identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the artist.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the artist's thumbnail image.
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }
    }
}
