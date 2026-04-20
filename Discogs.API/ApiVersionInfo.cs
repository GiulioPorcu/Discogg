using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents version information returned by the API.
    /// </summary>
    public class ApiVersionInfo
    {
        /// <summary>
        /// Gets or sets the greeting text returned by the API.
        /// </summary>
        [JsonPropertyName("hello")]
        public string? GreetingText { get; set; }

        /// <summary>
        /// Gets or sets the API version string.
        /// </summary>
        [JsonPropertyName("api_version")]
        public string? ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the URL to the API documentation.
        /// </summary>
        [JsonPropertyName("documentation_url")]
        public string? DocumentationUrl { get; set; }

        /// <summary>
        /// Gets or sets statistical information about the API.
        /// </summary>
        [JsonPropertyName("statistics")]
        public ApiInfoStatistics? Statistics { get; set; }
    }
}
