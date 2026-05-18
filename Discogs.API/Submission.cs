using System.Text.Json.Serialization;

namespace Discogs.API.Core
{
    /// <summary>
    /// Represents a submission containing artists, labels, and releases.
    /// </summary>
    public class Submission
    {
        /// <summary>
        /// Gets or sets the artists included in the submission.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[]? Artists { get; set; }

        /// <summary>
        /// Gets or sets the labels included in the submission.
        /// </summary>
        [JsonPropertyName("labels")]
        public Label[]? Labels { get; set; }

        /// <summary>
        /// Gets or sets the releases included in the submission.
        /// </summary>
        [JsonPropertyName("releases")]
        public Release[]? Releases { get; set; }
    }
}
