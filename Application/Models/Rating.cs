using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Rating
    {
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        [JsonPropertyName("average")]
        public float? Average { get; set; }
    }
}
