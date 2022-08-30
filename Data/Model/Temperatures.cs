using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using MongoDB.Bson;

namespace Data.Model
{
    [BsonIgnoreExtraElements]
    public partial class Temperatures
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("listing_url")]
        //public Uri ListingUrl { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("summary")]
        [BsonRepresentation(BsonType.String)]
        public string Summary { get; set; }

        [BsonElement("space")]
        [BsonRepresentation(BsonType.String)]
        public string Space { get; set; }

        [BsonElement("description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("neighborhood_overview")]
        [BsonRepresentation(BsonType.String)]
        public string NeighborhoodOverview { get; set; }

        [BsonElement("notes")]
        [BsonRepresentation(BsonType.String)]
        public string Notes { get; set; }

        [BsonElement("transit")]
        [BsonRepresentation(BsonType.String)]
        public string Transit { get; set; }

        [BsonElement("access")]
        [BsonRepresentation(BsonType.String)]
        public string Access { get; set; }

        [BsonElement("interaction")]
        [BsonRepresentation(BsonType.String)]
        public string Interaction { get; set; }

        [BsonElement("house_rules")]
        [BsonRepresentation(BsonType.String)]
        public string HouseRules { get; set; }

        [BsonElement("property_type")]
        [BsonRepresentation(BsonType.String)]
        public string PropertyType { get; set; }

        [BsonElement("room_type")]
        [BsonRepresentation(BsonType.String)]
        public string RoomType { get; set; }

        [BsonElement("bed_type")]
        [BsonRepresentation(BsonType.String)]
        public string BedType { get; set; }

        [BsonElement("minimum_nights")]
        [BsonRepresentation(BsonType.Int64)]
        public long MinimumNights { get; set; }

        [BsonElement("maximum_nights")]
        [BsonRepresentation(BsonType.Int64)]
        public long MaximumNights { get; set; }

        [BsonElement("cancellation_policy")]
        [BsonRepresentation(BsonType.String)]
        public string CancellationPolicy { get; set; }

        //[BsonElement("last_scraped")]
        //public CalendarLastScraped LastScraped { get; set; }

        //[BsonElement("calendar_last_scraped")]
        //public CalendarLastScraped CalendarLastScraped { get; set; }

        //[BsonElement("first_review")]
        //public CalendarLastScraped FirstReview { get; set; }

        //[BsonElement("last_review")]
        //public CalendarLastScraped LastReview { get; set; }

        //[BsonElement("accommodates")]
        //public Accommodates Accommodates { get; set; }

        //[BsonElement("bedrooms")]
        //public Accommodates Bedrooms { get; set; }

        //[BsonElement("beds")]
        //public Accommodates Beds { get; set; }

        //[BsonElement("number_of_reviews")]
        //public Accommodates NumberOfReviews { get; set; }

        //[BsonElement("bathrooms")]
        //public Bathrooms Bathrooms { get; set; }

        //[BsonElement("amenities")]
        //public string[] Amenities { get; set; }

        //[BsonElement("price")]
        //public Bathrooms Price { get; set; }

        //[BsonElement("security_deposit")]
        //public Bathrooms SecurityDeposit { get; set; }

        //[BsonElement("cleaning_fee")]
        //public Bathrooms CleaningFee { get; set; }

        //[BsonElement("extra_people")]
        //public Bathrooms ExtraPeople { get; set; }

        //[BsonElement("guests_included")]
        //public Bathrooms GuestsIncluded { get; set; }

        //[BsonElement("images")]
        //public Images Images { get; set; }

        //[BsonElement("host")]
        //public Host Host { get; set; }

        //[BsonElement("address")]
        //public Address Address { get; set; }

        //[BsonElement("availability")]
        //public Availability Availability { get; set; }

        //[BsonElement("review_scores")]
        //public ReviewScores ReviewScores { get; set; }

        //[BsonElement("reviews")]
        //public Review[] Reviews { get; set; }
    }

    public partial class Accommodates
    {
        [BsonElement("$numberInt")]

        public long NumberInt { get; set; }
    }

    public partial class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("suburb")]
        public string Suburb { get; set; }

        [BsonElement("government_area")]
        public string GovernmentArea { get; set; }

        [BsonElement("market")]
        public string Market { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("country_code")]
        public string CountryCode { get; set; }

        [BsonElement("location")]
        public Location Location { get; set; }
    }

    public partial class Location
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("coordinates")]
        public Coordinate[] Coordinates { get; set; }

        [BsonElement("is_location_exact")]
        public bool IsLocationExact { get; set; }
    }

    public partial class Coordinate
    {
        [BsonElement("$numberDouble")]
        public string NumberDouble { get; set; }
    }

    public partial class Availability
    {
        [BsonElement("availability_30")]
        public Accommodates Availability30 { get; set; }

        [BsonElement("availability_60")]
        public Accommodates Availability60 { get; set; }

        [BsonElement("availability_90")]
        public Accommodates Availability90 { get; set; }

        [BsonElement("availability_365")]
        public Accommodates Availability365 { get; set; }
    }

    public partial class Bathrooms
    {
        [BsonElement("$numberDecimal")]
        public string NumberDecimal { get; set; }
    }

    public partial class CalendarLastScraped
    {
        [BsonElement("$date")]
        public Date Date { get; set; }
    }

    public partial class Date
    {
        [BsonElement("$numberLong")]
        public string NumberLong { get; set; }
    }

    public partial class Host
    {
        [BsonElement("host_id")]

        public long HostId { get; set; }

        [BsonElement("host_url")]
        public Uri HostUrl { get; set; }

        [BsonElement("host_name")]
        public string HostName { get; set; }

        [BsonElement("host_location")]
        public string HostLocation { get; set; }

        [BsonElement("host_about")]
        public string HostAbout { get; set; }

        [BsonElement("host_response_time")]
        public string HostResponseTime { get; set; }

        [BsonElement("host_thumbnail_url")]
        public Uri HostThumbnailUrl { get; set; }

        [BsonElement("host_picture_url")]
        public Uri HostPictureUrl { get; set; }

        [BsonElement("host_neighbourhood")]
        public string HostNeighbourhood { get; set; }

        [BsonElement("host_response_rate")]
        public Accommodates HostResponseRate { get; set; }

        [BsonElement("host_is_superhost")]
        public bool HostIsSuperhost { get; set; }

        [BsonElement("host_has_profile_pic")]
        public bool HostHasProfilePic { get; set; }

        [BsonElement("host_identity_verified")]
        public bool HostIdentityVerified { get; set; }

        [BsonElement("host_listings_count")]
        public Accommodates HostListingsCount { get; set; }

        [BsonElement("host_total_listings_count")]
        public Accommodates HostTotalListingsCount { get; set; }

        [BsonElement("host_verifications")]
        public string[] HostVerifications { get; set; }
    }

    public partial class Images
    {
        [BsonElement("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [BsonElement("medium_url")]
        public string MediumUrl { get; set; }

        [BsonElement("picture_url")]
        public Uri PictureUrl { get; set; }

        [BsonElement("xl_picture_url")]
        public string XlPictureUrl { get; set; }
    }

    public partial class ReviewScores
    {
        [BsonElement("review_scores_accuracy")]
        public Accommodates ReviewScoresAccuracy { get; set; }

        [BsonElement("review_scores_cleanliness")]
        public Accommodates ReviewScoresCleanliness { get; set; }

        [BsonElement("review_scores_checkin")]
        public Accommodates ReviewScoresCheckin { get; set; }

        [BsonElement("review_scores_communication")]
        public Accommodates ReviewScoresCommunication { get; set; }

        [BsonElement("review_scores_location")]
        public Accommodates ReviewScoresLocation { get; set; }

        [BsonElement("review_scores_value")]
        public Accommodates ReviewScoresValue { get; set; }

        [BsonElement("review_scores_rating")]
        public Accommodates ReviewScoresRating { get; set; }
    }

    public partial class Review
    {
        [BsonElement("_id")]

        public long Id { get; set; }

        [BsonElement("date")]
        public CalendarLastScraped Date { get; set; }

        [BsonElement("listing_id")]

        public long ListingId { get; set; }

        [BsonElement("reviewer_id")]

        public long ReviewerId { get; set; }

        [BsonElement("reviewer_name")]
        public string ReviewerName { get; set; }

        [BsonElement("comments")]
        public string Comments { get; set; }
    }
}
