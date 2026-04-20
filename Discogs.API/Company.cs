using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents a company or label associated with a release.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the catalog number assigned by the company.
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
        /// Gets or sets the company identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the company.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the company's thumbnail image.
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }
    }
}