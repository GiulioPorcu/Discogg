using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Format
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("qty")]
        public string? Quantity { get; set; }

        [JsonPropertyName("descriptions")]
        public string[] Descriptions { get; set; } = [];

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
