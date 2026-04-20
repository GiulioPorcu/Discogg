using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents a Discogs user collection folder.
    /// </summary>
    public class UserCollectionFolder
    {
        /// <summary>
        /// Gets or sets the user collection folder identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the user collection folder instance identifier.
        /// </summary>
        [JsonPropertyName("instance_id")]
        public int? InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the user collection folder ID this folder belongs to.
        /// </summary>
        [JsonPropertyName("folder_id")]
        public int? FolderId { get; set; }

        /// <summary>
        /// Gets or sets the date this folder got added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public string? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the user's rating for this folder.
        /// </summary>
        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        /// <summary>
        /// Gets or sets release information.
        /// </summary>
        [JsonPropertyName("basic_information")]
        public Release? BasicInformation { get; set; }
    }
}