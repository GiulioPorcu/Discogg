using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Submitter
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }
    }
}
