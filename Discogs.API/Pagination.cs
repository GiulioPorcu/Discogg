using System.Text.Json.Serialization;

namespace Discogs.API
{
    /// <summary>
    /// Represents a paginated response from the Discogs API.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Gets or sets the page number (1-indexed).
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        [JsonPropertyName("pages")]
        public int? Pages { get; set; }

        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        [JsonPropertyName("items")]
        public int? Items { get; set; }

        /// <summary>
        /// Gets or sets the URLs for pagination navigation.
        /// </summary>
        [JsonPropertyName("urls")]
        public PaginationUrls? Urls { get; set; }
    }

    /// <summary>
    /// Represents pagination navigation URLs.
    /// </summary>
    public class PaginationUrls
    {
        /// <summary>
        /// Gets or sets the URL to the first page.
        /// </summary>
        [JsonPropertyName("first")]
        public string? First { get; set; }

        /// <summary>
        /// Gets or sets the URL to the previous page.
        /// </summary>
        [JsonPropertyName("prev")]
        public string? Prev { get; set; }

        /// <summary>
        /// Gets or sets the URL to the next page.
        /// </summary>
        [JsonPropertyName("next")]
        public string? Next { get; set; }

        /// <summary>
        /// Gets or sets the URL to the last page.
        /// </summary>
        [JsonPropertyName("last")]
        public string? Last { get; set; }
    }

    /// <summary>
    /// Represents a paginated response wrapper.
    /// </summary>
    /// <typeparam name="T">The type of items in the response.</typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// Gets or sets the pagination information.
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }

        /// <summary>
        /// Gets or sets the array of items.
        /// </summary>
        [JsonPropertyName("results")]
        public T[]? Results { get; set; }

        /// <summary>
        /// Gets or sets the releases array (used in some endpoints).
        /// </summary>
        [JsonPropertyName("releases")]
        public T[]? Releases { get; set; }
    }

    /// <summary>
    /// Represents a collection folder with its items.
    /// </summary>
    public class CollectionFolder
    {
        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the resource URL.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the user resource URL.
        /// </summary>
        [JsonPropertyName("user_resource_url")]
        public string? UserResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the count of items in the folder.
        /// </summary>
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the date the folder was created.
        /// </summary>
        [JsonPropertyName("date_added")]
        public string? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date the folder was last modified.
        /// </summary>
        [JsonPropertyName("date_modified")]
        public string? DateModified { get; set; }
    }

    /// <summary>
    /// Represents an item in a user's collection.
    /// </summary>
    public class CollectionItem
    {
        /// <summary>
        /// Gets or sets the instance identifier.
        /// </summary>
        [JsonPropertyName("instance_id")]
        public int? InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        [JsonPropertyName("folder_id")]
        public int? FolderId { get; set; }

        /// <summary>
        /// Gets or sets the date the item was added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public string? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date the item was last modified.
        /// </summary>
        [JsonPropertyName("date_modified")]
        public string? DateModified { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the user.
        /// </summary>
        [JsonPropertyName("rating")]
        public int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the basic information.
        /// </summary>
        [JsonPropertyName("basic_information")]
        public Release? BasicInformation { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        [JsonPropertyName("custom_fields")]
        public Dictionary<string, object>? CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the notes for this item.
        /// </summary>
        [JsonPropertyName("notes")]
        public CollectionItemNote[]? Notes { get; set; }
    }

    /// <summary>
    /// Represents a note on a collection item.
    /// </summary>
    public class CollectionItemNote
    {
        /// <summary>
        /// Gets or sets the field identifier.
        /// </summary>
        [JsonPropertyName("field_id")]
        public int? FieldId { get; set; }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [JsonPropertyName("field_name")]
        public string? FieldName { get; set; }

        /// <summary>
        /// Gets or sets the note value.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    /// <summary>
    /// Represents marketplace price suggestions.
    /// </summary>
    public class PriceSuggestion
    {
        /// <summary>
        /// Gets or sets the very good price suggestion.
        /// </summary>
        [JsonPropertyName("very_good")]
        public float? VeryGood { get; set; }

        /// <summary>
        /// Gets or sets the good plus price suggestion.
        /// </summary>
        [JsonPropertyName("good_plus")]
        public float? GoodPlus { get; set; }

        /// <summary>
        /// Gets or sets the good price suggestion.
        /// </summary>
        [JsonPropertyName("good")]
        public float? Good { get; set; }

        /// <summary>
        /// Gets or sets the fair price suggestion.
        /// </summary>
        [JsonPropertyName("fair")]
        public float? Fair { get; set; }

        /// <summary>
        /// Gets or sets the poor price suggestion.
        /// </summary>
        [JsonPropertyName("poor")]
        public float? Poor { get; set; }

        /// <summary>
        /// Gets or sets the mint price suggestion.
        /// </summary>
        [JsonPropertyName("mint")]
        public float? Mint { get; set; }

        /// <summary>
        /// Gets or sets the near mint price suggestion.
        /// </summary>
        [JsonPropertyName("near_mint")]
        public float? NearMint { get; set; }
    }

    /// <summary>
    /// Represents marketplace statistics for a release.
    /// </summary>
    public class MarketplaceStats
    {
        /// <summary>
        /// Gets or sets the number of listings for sale.
        /// </summary>
        [JsonPropertyName("num_for_sale")]
        public int? NumberForSale { get; set; }

        /// <summary>
        /// Gets or sets the lowest price.
        /// </summary>
        [JsonPropertyName("lowest_price")]
        public float? LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets the median price.
        /// </summary>
        [JsonPropertyName("median_price")]
        public float? MedianPrice { get; set; }

        /// <summary>
        /// Gets or sets the lowest price with condition.
        /// </summary>
        [JsonPropertyName("lowest_price_with_condition")]
        public PriceByCondition? LowestPriceWithCondition { get; set; }

        /// <summary>
        /// Gets or sets the number of sales in the last period.
        /// </summary>
        [JsonPropertyName("num_sales")]
        public int? NumberOfSales { get; set; }
    }

    /// <summary>
    /// Represents prices by condition.
    /// </summary>
    public class PriceByCondition
    {
        /// <summary>
        /// Gets or sets the mint price.
        /// </summary>
        [JsonPropertyName("mint")]
        public float? Mint { get; set; }

        /// <summary>
        /// Gets or sets the near mint price.
        /// </summary>
        [JsonPropertyName("near_mint")]
        public float? NearMint { get; set; }

        /// <summary>
        /// Gets or sets the very good plus price.
        /// </summary>
        [JsonPropertyName("very_good_plus")]
        public float? VeryGoodPlus { get; set; }

        /// <summary>
        /// Gets or sets the very good price.
        /// </summary>
        [JsonPropertyName("very_good")]
        public float? VeryGood { get; set; }

        /// <summary>
        /// Gets or sets the good plus price.
        /// </summary>
        [JsonPropertyName("good_plus")]
        public float? GoodPlus { get; set; }

        /// <summary>
        /// Gets or sets the good price.
        /// </summary>
        [JsonPropertyName("good")]
        public float? Good { get; set; }

        /// <summary>
        /// Gets or sets the fair price.
        /// </summary>
        [JsonPropertyName("fair")]
        public float? Fair { get; set; }

        /// <summary>
        /// Gets or sets the poor price.
        /// </summary>
        [JsonPropertyName("poor")]
        public float? Poor { get; set; }
    }

    /// <summary>
    /// Represents a fee calculation result.
    /// </summary>
    public class FeeResult
    {
        /// <summary>
        /// Gets or sets the Discogs fee amount.
        /// </summary>
        [JsonPropertyName("discogs_fee")]
        public float? DiscogsFee { get; set; }

        /// <summary>
        /// Gets or sets the payment processing fee amount.
        /// </summary>
        [JsonPropertyName("processing_fee")]
        public float? ProcessingFee { get; set; }

        /// <summary>
        /// Gets or sets the total fee amount.
        /// </summary>
        [JsonPropertyName("total")]
        public float? Total { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Gets or sets the net amount to the seller.
        /// </summary>
        [JsonPropertyName("net")]
        public float? Net { get; set; }
    }

    /// <summary>
    /// Represents a submission containing a release ID.
    /// </summary>
    public class Submission
    {
        /// <summary>
        /// Gets or sets the release identifier.
        /// </summary>
        [JsonPropertyName("release_id")]
        public int? ReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the resource URL.
        /// </summary>
        [JsonPropertyName("resource_url")]
        public string? ResourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the Discogs URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the date added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public string? DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date changed.
        /// </summary>
        [JsonPropertyName("date_changed")]
        public string? DateChanged { get; set; }
    }
}
