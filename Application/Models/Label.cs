using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Label
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("catno")]
        public string? CatNo { get; set; }

        [JsonPropertyName("entity_type")]
        public string? EntityType { get; set; }

        [JsonPropertyName("entity_type_name")]
        public string? EntityTypeName { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }
    }
}
