using System.Text.Json.Serialization;

namespace Application.Models
{
    public class ApiInfo
    {
        [JsonPropertyName("hello")]
        public string? GreetingText { get; set; }

        [JsonPropertyName("api_version")]
        public string? ApiVersion { get; set; }

        [JsonPropertyName("documentation_url")]
        public string? DocumentationUrl { get; set; }

        [JsonPropertyName("statistics")]
        public ApiInfoStatistics? Statistics { get; set; }
    }

    public class ApiInfoStatistics
    {
        [JsonPropertyName("releases")]
        public int? Releases { get; set; }

        [JsonPropertyName("artists")]
        public int? Artists { get; set; }

        [JsonPropertyName("labels")]
        public int? Labels { get; set; }
    }
}
