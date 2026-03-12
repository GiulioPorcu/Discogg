using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Identifier
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}