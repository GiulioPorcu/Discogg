using System.Text.Json.Serialization;

namespace Application.Models
{
    public class Release
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];

        [JsonPropertyName("artists_sort")]
        public string? ArtistsSort { get; set; }

        [JsonPropertyName("labels")]
        public Label[] Labels { get; set; } = [];

        [JsonPropertyName("series")]
        public object[] Series { get; set; } = []; // TODO object to series object

        [JsonPropertyName("companies")]
        public Company[] Companies { get; set; } = [];

        [JsonPropertyName("formats")]
        public Format[] Formats { get; set; } = [];

        [JsonPropertyName("data_quality")]
        public string? DataQuality { get; set; }

        [JsonPropertyName("community")]
        public Community? Community { get; set; }

        [JsonPropertyName("format_quantity")]
        public int? FormatQuantity { get; set; }

        [JsonPropertyName("date_added")]
        public DateTime? DateAdded { get; set; }

        [JsonPropertyName("date_changed")]
        public DateTime? DateChanged { get; set; }

        [JsonPropertyName("num_for_sale")]
        public int? NumForSale { get; set; }

        [JsonPropertyName("lowest_price")]
        public float? LowestPrice { get; set; }

        [JsonPropertyName("master_id")]
        public int? MasterId { get; set; }

        [JsonPropertyName("master_url")]
        public string? MasterUrl { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("released")]
        public string? Released { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("released_formatted")]
        public string? ReleasedFormatted { get; set; }

        [JsonPropertyName("identifiers")]
        public Identifier[] Identifiers { get; set; } = [];

        [JsonPropertyName("videos")]
        public Video[] Videos { get; set; } = [];

        [JsonPropertyName("genres")]
        public string?[] Genres { get; set; } = [];

        [JsonPropertyName("styles")]
        public string?[] Styles { get; set; } = [];

        [JsonPropertyName("tracklist")]
        public Track[] Tracks { get; set; } = [];

        [JsonPropertyName("extraartists")]
        public Artist[] ExtraArtists { get; set; } = [];

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

        [JsonPropertyName("estimated_weight")]
        public int? EstimatedWeight { get; set; }

        [JsonPropertyName("blocked_from_sale")]
        public bool? BlockedFromSale { get; set; }

        [JsonPropertyName("is_offensive")]
        public bool? IsOffensive { get; set; }
    }
}