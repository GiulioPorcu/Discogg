using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents a label associated with a release.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Gets or sets the label name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the catalog number assigned by the label.
        /// </summary>
        [JsonPropertyName("catno")]
        public string? CatalogNumber { get; set; }

        /// <summary>
        /// Gets or sets the numeric entity type identifier.
        /// </summary>
        [JsonPropertyName("entity_type")]
        public string? EntityType { get; set; }

        /// <summary>
        /// Gets or sets the descriptive name of the entity type.
        /// </summary>
        [JsonPropertyName("entity_type_name")]
        public string? EntityTypeName { get; set; }

        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the label.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the label's thumbnail image.
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }
    }
}
