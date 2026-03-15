using System.Text.Json.Serialization;

namespace Application.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("home_page")]
        public string? HomePage { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("profile")]
        public string? Profile { get; set; }

        [JsonPropertyName("registered")]
        public string? Registered { get; set; }

        [JsonPropertyName("rank")]
        public double? Rank { get; set; }

        [JsonPropertyName("num_pending")]
        public int? NumPending { get; set; }

        [JsonPropertyName("num_for_sale")]
        public int? NumForSale { get; set; }

        [JsonPropertyName("num_lists")]
        public int? NumLists { get; set; }

        [JsonPropertyName("releases_contributed")]
        public int? ReleasesContributed { get; set; }

        [JsonPropertyName("releases_rated")]
        public int? ReleasesRated { get; set; }

        [JsonPropertyName("rating_avg")]
        public double? RatingAverage { get; set; }

        [JsonPropertyName("inventory_url")]
        public string? InventoryUrl { get; set; }

        [JsonPropertyName("collection_folders_url")]
        public string? CollectionFoldersUrl { get; set; }

        [JsonPropertyName("collection_fields_url")]
        public string? CollectionFieldsUrl { get; set; }

        [JsonPropertyName("wantlist_url")]
        public string? WantListUrl { get; set; }

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("curr_abbr")]
        public string? CurrencyAbbreviated { get; set; }

        [JsonPropertyName("activated")]
        public bool? Activated { get; set; }

        [JsonPropertyName("marketplace_suspended")]
        public bool? MarketplaceSuspended { get; set; }

        [JsonPropertyName("banner_url")]
        public string? BannerUrl { get; set; }

        [JsonPropertyName("buyer_rating")]
        public double? BuyerRating { get; set; }

        [JsonPropertyName("buyer_rating_stars")]
        public double? BuyerRatingStars { get; set; }

        [JsonPropertyName("buyer_num_ratings")]
        public int? BuyerNumRatings { get; set; }

        [JsonPropertyName("seller_rating")]
        public double? SellerRating { get; set; }

        [JsonPropertyName("seller_rating_stars")]
        public double? SellerRatingStars { get; set; }

        [JsonPropertyName("seller_num_ratings")]
        public int? SellerNumRatings { get; set; }

        [JsonPropertyName("is_staff")]
        public bool? IsStaff { get; set; }

        [JsonPropertyName("num_collection")]
        public int? NumCollection { get; set; }

        [JsonPropertyName("num_wantlist")]
        public int? NumWantList { get; set; }
    }
}