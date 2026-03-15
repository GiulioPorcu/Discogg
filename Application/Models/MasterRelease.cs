using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents detailed metadata for a release, including identifiers, images,
    /// artists, tracks, pricing, and related URLs.
    /// </summary>
    public class MasterRelease
    {
        /// <summary>
        /// Gets or sets the release identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the main release in the master record.
        /// </summary>
        [JsonPropertyName("main_release")]
        public int? MainReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the most recent release in the master record.
        /// </summary>
        [JsonPropertyName("most_recent_release")]
        public int? MostRecentReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for this release.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the Discogs URI for this release.
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// Gets or sets the URL for retrieving all versions of this release.
        /// </summary>
        [JsonPropertyName("versions_url")]
        public string? VersionsUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the main release.
        /// </summary>
        [JsonPropertyName("main_release_url")]
        public string? MainReleaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the most recent release.
        /// </summary>
        [JsonPropertyName("most_recent_release_url")]
        public string? MostRecentReleaceUrl { get; set; }

        /// <summary>
        /// Gets or sets the number of copies currently for sale.
        /// </summary>
        [JsonPropertyName("num_for_sale")]
        public int? NumberForSale { get; set; }

        /// <summary>
        /// Gets or sets the lowest marketplace price for this release.
        /// </summary>
        [JsonPropertyName("lowest_price")]
        public float? LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets the images associated with this release.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        /// <summary>
        /// Gets or sets the genres associated with this release.
        /// </summary>
        [JsonPropertyName("genres")]
        public string?[] Genres { get; set; } = [];

        /// <summary>
        /// Gets or sets the styles associated with this release.
        /// </summary>
        [JsonPropertyName("styles")]
        public string?[] Styles { get; set; } = [];

        /// <summary>
        /// Gets or sets the release year.
        /// </summary>
        [JsonPropertyName("year")]
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the tracklist for this release.
        /// </summary>
        [JsonPropertyName("tracks")]
        public Track[] Tracks { get; set; } = [];

        /// <summary>
        /// Gets or sets the artists credited on this release.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];

        /// <summary>
        /// Gets or sets the release title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the release notes.
        /// </summary>
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the data quality rating assigned by the community.
        /// </summary>
        [JsonPropertyName("data_quality")]
        public string? DataQualityStatus { get; set; }

        /// <summary>
        /// Gets or sets the videos associated with this release.
        /// </summary>
        [JsonPropertyName("videos")]
        public Video[] Videos { get; set; } = [];
    }
}