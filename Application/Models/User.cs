using System.Text.Json.Serialization;

namespace Application.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        [JsonPropertyName("consumer_name")]
        public string? ConsumerName { get; set; }

        [JsonIgnore]
        public UserDetails? Details { get; set; }

        [JsonIgnore]
        public string? Token { get; set; }
    }
}