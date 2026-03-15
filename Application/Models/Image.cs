using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents an image associated with a release, including URLs and dimensions.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the image type (e.g., primary, secondary).
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the full‑size image URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the image.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the 150‑pixel thumbnail URI.
        /// </summary>
        [JsonPropertyName("uri150")]
        public string? Uri150 { get; set; }

        /// <summary>
        /// Gets or sets the image width in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the image height in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
    }
}