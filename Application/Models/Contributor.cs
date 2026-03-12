using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Contributor
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }
    }
}
