using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discogs.API
{
    /// <summary>
    /// Represents statistical information returned by the API.
    /// </summary>
    public class ApiInfoStatistics
    {
        /// <summary>
        /// Gets or sets the number of releases.
        /// </summary>
        [JsonPropertyName("releases")]
        public int? Releases { get; set; }

        /// <summary>
        /// Gets or sets the number of artists.
        /// </summary>
        [JsonPropertyName("artists")]
        public int? Artists { get; set; }

        /// <summary>
        /// Gets or sets the number of labels.
        /// </summary>
        [JsonPropertyName("labels")]
        public int? Labels { get; set; }
    }
}
