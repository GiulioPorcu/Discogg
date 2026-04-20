using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents an artist entry returned by the API.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Gets or sets the artist's display name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the artist's alternative name variation.
        /// </summary>
        [JsonPropertyName("anv")]
        public string? AlternativeNameVariation { get; set; }

        /// <summary>
        /// Gets or sets the join phrase used when multiple artists are listed together.
        /// </summary>
        [JsonPropertyName("join")]
        public string? JoinPhrase { get; set; }

        /// <summary>
        /// Gets or sets the artist's role or contribution.
        /// </summary>
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets the track numbers associated with the artist.
        /// </summary>
        [JsonPropertyName("tracks")]
        public string? Tracks { get; set; }

        /// <summary>
        /// Gets or sets the artist's identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the API resource URL for the artist.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL of the artist's thumbnail image.
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the artist's profile text.
        /// </summary>
        [JsonPropertyName("profile")]
        public string? Profile { get; set; }

        /// <summary>
        /// Gets or sets the URLs associated with the artist (website, social media, etc.).
        /// </summary>
        [JsonPropertyName("urls")]
        public string[]? Urls { get; set; }

        /// <summary>
        /// Gets or sets the URL for the artist's images.
        /// </summary>
        [JsonPropertyName("images_url")]
        public string? ImagesUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL for the artist's releases.
        /// </summary>
        [JsonPropertyName("releases_url")]
        public string? ReleasesUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL for the artist's name variations page.
        /// </summary>
        [JsonPropertyName("namevariations")]
        public string[]? NameVariations { get; set; }

        /// <summary>
        /// Gets or sets the real name of the artist.
        /// </summary>
        [JsonPropertyName("realname")]
        public string? RealName { get; set; }

        /// <summary>
        /// Gets or sets the associated label information.
        /// </summary>
        [JsonPropertyName("labels")]
        public string[]? Labels { get; set; }

        /// <summary>
        /// Gets or sets the data quality status.
        /// </summary>
        [JsonPropertyName("data_quality")]
        public string? DataQuality { get; set; }

        /// <summary>
        /// Gets or sets the number of releases.
        /// </summary>
        [JsonPropertyName("releases_count")]
        public int? ReleasesCount { get; set; }

        /// <summary>
        /// Gets or sets the images array.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[]? Images { get; set; }

        /// <summary>
        /// Gets or sets the sub-groups/members of the artist (for groups).
        /// </summary>
        [JsonPropertyName("members")]
        public Artist[]? Members { get; set; }

        /// <summary>
        /// Gets or sets the aliases (related artists with alternate names).
        /// </summary>
        [JsonPropertyName("aliases")]
        public Artist[]? Aliases { get; set; }

        /// <summary>
        /// Gets or sets the groups the artist belongs to.
        /// </summary>
        [JsonPropertyName("groups")]
        public Artist[]? Groups { get; set; }

        /// <summary>
        /// Gets or sets the Discogs URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// Gets or sets the resource URL for releases.
        /// </summary>
        [JsonPropertyName("releases_resource_url")]
        public string? ReleasesResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the URI to the user's wantlist for this artist.
        /// </summary>
        [JsonPropertyName("uri_wantlist")]
        public string? UriWantlist { get; set; }

        /// <summary>
        /// Gets or sets the URI to the user's collection for this artist.
        /// </summary>
        [JsonPropertyName("uri_collection")]
        public string? UriCollection { get; set; }

        /// <summary>
        /// Gets or sets the submission count.
        /// </summary>
        [JsonPropertyName("num_submissions")]
        public int? NumSubmissions { get; set; }

        /// <summary>
        /// Gets or sets the rating count.
        /// </summary>
        [JsonPropertyName("num_ratings")]
        public int? NumRatings { get; set; }

        /// <summary>
        /// Gets or sets the average rating.
        /// </summary>
        [JsonPropertyName("rating")]
        public float? Rating { get; set; }
    }
}
