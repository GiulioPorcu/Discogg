using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents a Discogs release with full metadata, including artists, formats,
    /// identifiers, images, pricing, community data, and related URLs.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// Gets or sets the release identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the release status (e.g., Accepted, Draft).
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the release year.
        /// </summary>
        [JsonPropertyName("year")]
        public int? Year { get; set; }

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
        /// Gets or sets the list of primary artists credited on the release.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];

        /// <summary>
        /// Gets or sets the sortable artist string.
        /// </summary>
        [JsonPropertyName("artists_sort")]
        public string? ArtistsSort { get; set; }

        /// <summary>
        /// Gets or sets the labels associated with the release.
        /// </summary>
        [JsonPropertyName("labels")]
        public Label[] Labels { get; set; } = [];

        /// <summary>
        /// Gets or sets the series information for the release.
        /// </summary>
        [JsonPropertyName("series")]
        public object[] Series { get; set; } = [];

        /// <summary>
        /// Gets or sets the companies involved in the release.
        /// </summary>
        [JsonPropertyName("companies")]
        public Company[] Companies { get; set; } = [];

        /// <summary>
        /// Gets or sets the release formats.
        /// </summary>
        [JsonPropertyName("formats")]
        public Format[] Formats { get; set; } = [];

        /// <summary>
        /// Gets or sets the data quality rating assigned by the community.
        /// </summary>
        [JsonPropertyName("data_quality")]
        public string? DataQualityStatus { get; set; }

        /// <summary>
        /// Gets or sets community metadata for the release.
        /// </summary>
        [JsonPropertyName("community")]
        public Community? Community { get; set; }

        /// <summary>
        /// Gets or sets the number of format items.
        /// </summary>
        [JsonPropertyName("format_quantity")]
        public int? FormatQuantity { get; set; }

        /// <summary>
        /// Gets or sets the date the release entry was added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public DateTime? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date the release entry was last changed.
        /// </summary>
        [JsonPropertyName("date_changed")]
        public DateTime? DateChanged { get; set; }

        /// <summary>
        /// Gets or sets the number of copies currently for sale.
        /// </summary>
        [JsonPropertyName("num_for_sale")]
        public int? NumberForSale { get; set; }

        /// <summary>
        /// Gets or sets the lowest marketplace price.
        /// </summary>
        [JsonPropertyName("lowest_price")]
        public float? LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets the master release identifier.
        /// </summary>
        [JsonPropertyName("master_id")]
        public int? MasterId { get; set; }

        /// <summary>
        /// Gets or sets the master release URL.
        /// </summary>
        [JsonPropertyName("master_url")]
        public string? MasterUrl { get; set; }

        /// <summary>
        /// Gets or sets the release title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the country of release.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the release date string.
        /// </summary>
        [JsonPropertyName("released")]
        public string? ReleasedDate { get; set; }

        /// <summary>
        /// Gets or sets the release notes.
        /// </summary>
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the formatted release date.
        /// </summary>
        [JsonPropertyName("released_formatted")]
        public string? ReleasedDateFormatted { get; set; }

        /// <summary>
        /// Gets or sets the identifiers associated with the release.
        /// </summary>
        [JsonPropertyName("identifiers")]
        public Identifier[] Identifiers { get; set; } = [];

        /// <summary>
        /// Gets or sets the videos linked to the release.
        /// </summary>
        [JsonPropertyName("videos")]
        public Video[] Videos { get; set; } = [];

        /// <summary>
        /// Gets or sets the genres associated with the release.
        /// </summary>
        [JsonPropertyName("genres")]
        public string?[] Genres { get; set; } = [];

        /// <summary>
        /// Gets or sets the styles associated with the release.
        /// </summary>
        [JsonPropertyName("styles")]
        public string?[] Styles { get; set; } = [];

        /// <summary>
        /// Gets or sets the tracklist for the release.
        /// </summary>
        [JsonPropertyName("tracklist")]
        public Track[] Tracks { get; set; } = [];

        /// <summary>
        /// Gets or sets additional artists credited on the release.
        /// </summary>
        [JsonPropertyName("extraartists")]
        public Artist[] ExtraArtists { get; set; } = [];

        /// <summary>
        /// Gets or sets the images associated with the release.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        /// <summary>
        /// Gets or sets the thumbnail image URL.
        /// </summary>
        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

        /// <summary>
        /// Gets or sets the estimated weight of the release package.
        /// </summary>
        [JsonPropertyName("estimated_weight")]
        public int? EstimatedWeight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the release is blocked from sale.
        /// </summary>
        [JsonPropertyName("blocked_from_sale")]
        public bool? BlockedFromSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the release contains offensive content.
        /// </summary>
        [JsonPropertyName("is_offensive")]
        public bool? IsOffensive { get; set; }
    }
}