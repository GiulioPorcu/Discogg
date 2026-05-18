using System.Text.Json.Serialization;

namespace Discogs.API.Core
{
    /// <summary>
    /// Represents a user's inventory with pagination and listings.
    /// </summary>
    public class UserInventory
    {
        /// <summary>
        /// Gets or sets the pagination information for the inventory.
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }

        /// <summary>
        /// Gets or sets the listings in the inventory.
        /// </summary>
        [JsonPropertyName("listings")]
        public Listing[]? Listings { get; set; }
    }
}
