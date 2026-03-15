using System.Text.Json.Serialization;

namespace Application.Models
{
    /// <summary>
    /// Represents an identifier associated with a release, such as a barcode or matrix number.
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// Gets or sets the identifier type (e.g., Barcode, Matrix / Runout).
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the identifier value.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// Gets or sets an optional description providing additional context.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}