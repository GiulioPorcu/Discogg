using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents a wantlist entry.
    /// </summary>
    public class Want
    {
        /// <summary>
        /// Gets or sets the want entry identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for this want entry.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the release identifier.
        /// </summary>
        [JsonPropertyName("release_id")]
        public int? ReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who added this item.
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the date the item was added to the wantlist.
        /// </summary>
        [JsonPropertyName("date_added")]
        public string? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date the item was last modified.
        /// </summary>
        [JsonPropertyName("date_modified")]
        public string? DateModified { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the user.
        /// </summary>
        [JsonPropertyName("rating")]
        public int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the release basic information.
        /// </summary>
        [JsonPropertyName("basic_information")]
        public Release? BasicInformation { get; set; }

        /// <summary>
        /// Gets or sets the notes for this want entry.
        /// </summary>
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the maximum price the user is willing to pay.
        /// </summary>
        [JsonPropertyName("max_price")]
        public int? MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the minimum condition the user accepts.
        /// </summary>
        [JsonPropertyName("min_condition")]
        public string? MinCondition { get; set; }

        /// <summary>
        /// Gets or sets the weight field (custom field).
        /// </summary>
        [JsonPropertyName("weight")]
        public string? Weight { get; set; }

        /// <summary>
        /// Gets or sets the format field (custom field).
        /// </summary>
        [JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <summary>
        /// Gets or sets the year field (custom field).
        /// </summary>
        [JsonPropertyName("year")]
        public string? Year { get; set; }

        /// <summary>
        /// Gets or sets the label field (custom field).
        /// </summary>
        [JsonPropertyName("label")]
        public string? Label { get; set; }

        /// <summary>
        /// Gets or sets the catalog number field (custom field).
        /// </summary>
        [JsonPropertyName("catno")]
        public string? CatalogNumber { get; set; }

        /// <summary>
        /// Gets or sets the barcode field (custom field).
        /// </summary>
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }
    }
}
