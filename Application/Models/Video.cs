using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents a video associated with a release, including metadata such as
    /// title, description, duration, and whether it supports embedding.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Gets or sets the video URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// Gets or sets the video title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the video description.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the video duration in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the video can be embedded.
        /// </summary>
        [JsonPropertyName("embed")]
        public bool? CanBeEmbedded { get; set; }
    }
}
