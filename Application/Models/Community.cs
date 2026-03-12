using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Community
    {
        [JsonPropertyName("have")]
        public int? Have { get; set; }

        [JsonPropertyName("want")]
        public int? Want { get; set; }

        [JsonPropertyName("rating")]
        public Rating? Rating { get; set; }

        [JsonPropertyName("submitter")]
        public Submitter? Submitter { get; set; }

        [JsonPropertyName("contributors")]
        public Contributor[] Contributors { get; set; } = [];

        [JsonPropertyName("data_quality")]
        public string? DataQuality { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
