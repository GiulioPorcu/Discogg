using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents community rating information for a release,
    /// including the number of ratings and the average score.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Gets or sets the number of users who submitted a rating.
        /// </summary>
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the average rating value.
        /// </summary>
        [JsonPropertyName("average")]
        public float? Average { get; set; }
    }
}
