using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Track
    {
        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("extraartists")]
        public Artist[] ExtraArtists { get; set; } = [];

        [JsonPropertyName("duration")]
        public string? Duration { get; set; }
    }
}
