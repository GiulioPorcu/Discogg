using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Video
    {
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [JsonPropertyName("embed")]
        public bool? Embed { get; set; }
    }
}
