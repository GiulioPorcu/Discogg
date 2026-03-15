using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents community-related metadata for a release.
    /// </summary>
    public class Community
    {
        /// <summary>
        /// Gets or sets how many users have this release in their collection.
        /// </summary>
        [JsonPropertyName("have")]
        public int? Haves { get; set; }

        /// <summary>
        /// Gets or sets how many users want this release.
        /// </summary>
        [JsonPropertyName("want")]
        public int? Wants { get; set; }

        /// <summary>
        /// Gets or sets the community rating information.
        /// </summary>
        [JsonPropertyName("rating")]
        public Rating? Rating { get; set; }

        /// <summary>
        /// Gets or sets the user who submitted the release.
        /// </summary>
        [JsonPropertyName("submitter")]
        public Submitter? Submitter { get; set; }

        /// <summary>
        /// Gets or sets the list of contributors involved in the release entry.
        /// </summary>
        [JsonPropertyName("contributors")]
        public Contributor[] Contributors { get; set; } = [];

        /// <summary>
        /// Gets or sets the data quality status assigned by the community.
        /// </summary>
        [JsonPropertyName("data_quality")]
        public string? DataQualityStatus { get; set; }

        /// <summary>
        /// Gets or sets the release status (e.g., accepted, draft).
        /// </summary>
        [JsonPropertyName("status")]
        public string? ReleaseStatus { get; set; }
    }
}
