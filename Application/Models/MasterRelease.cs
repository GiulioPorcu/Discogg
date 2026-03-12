using System.Text.Json.Serialization;

namespace Application.Models
{
    public class MasterRelease
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("main_release")]
        public int? MainReleaseId { get; set; }

        [JsonPropertyName("most_recent_release")]
        public int? MostRecentReleaseId { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("versions_url")]
        public string? VersionsUrl { get; set; }

        [JsonPropertyName("main_release_url")]
        public string? MainReleaseUrl { get; set; }

        [JsonPropertyName("most_recent_release_url")]
        public string? MostRecentReleaceUrl { get; set; }

        [JsonPropertyName("num_for_sale")]
        public int? NumForSale { get; set; }

        [JsonPropertyName("lowest_price")]
        public float? LowestPrice { get; set; }

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        [JsonPropertyName("genres")]
        public string?[] Genres { get; set; } = [];

        [JsonPropertyName("styles")]
        public string?[] Styles { get; set; } = [];

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("tracks")]
        public Track[] Tracks { get; set; } = [];

        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("data_quality")]
        public string? DataQuality { get; set; }

        [JsonPropertyName("videos")]
        public Video[] Videos { get; set; } = [];
    }
}