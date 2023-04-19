using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Model.Concrete;
using Paximum.Response.OfferDetail;

namespace HotelProduct
{
    public class GetProductInfoRequest
    {
        [JsonProperty("productType")]
        public int ProductType { get; set; }

        [JsonProperty("ownerProvider")]
        public int OwnerProvider { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Board
    {
        [JsonProperty("presentations")]
        public List<Presentation> Presentations { get; set; }

        [JsonProperty("mediaFiles")]
        public List<MediaFile> MediaFiles { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Body
    {
        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }
    }

    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Facility
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("isPriced")]
        public bool IsPriced { get; set; }

        [JsonProperty("highlighted")]
        public bool Highlighted { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class FacilityCategory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("facilities")]
        public List<Facility> Facilities { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Geolocation
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }

    public class Header
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseTime")]
        public DateTime ResponseTime { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }

    public class Hotel
    {
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }

        [JsonProperty("faxNumber")]
        public string FaxNumber { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("homePage")]
        public string HomePage { get; set; }

        [JsonProperty("rooms")]
        public List<Room> Rooms { get; set; }

        [JsonProperty("boards")]
        public List<Board> Boards { get; set; }

        [JsonProperty("stopSaleGuaranteed")]
        public int StopSaleGuaranteed { get; set; }

        [JsonProperty("stopSaleStandart")]
        public int StopSaleStandart { get; set; }

        [JsonProperty("paymentPlanInfo")]
        public List<PaymentPlanInfo> PaymentPlanInfo { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("town")]
        public Town Town { get; set; }

        [JsonProperty("hotelCategory")]
        public HotelCategory HotelCategory { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class HotelCategory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class MediaFile
    {
        [JsonProperty("fileType")]
        public int FileType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlFull")]
        public string UrlFull { get; set; }
    }

    public class Message
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("messageType")]
        public int MessageType { get; set; }

        [JsonProperty("message")]
        public string Messages { get; set; }
    }

    public class PaymentPlanInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("phase")]
        public int Phase { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("paymentTimeStatus")]
        public int PaymentTimeStatus { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }

    public class Presentation
    {
        [JsonProperty("textType")]
        public int TextType { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Price
    {
        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }

    public class Room
    {
        public List<HotelFacilities> Facilities { get; set; }
        public List<HotelSeasonMediaFiles> MediaFiles { get; set; }
        public List<Traveller> Travellers { get; set; }
        public List<HotelPresentation> presentations { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string BoardId { get; set; }
        public string BoardName { get; set; }
        public string RoomInfoId { get; set; }
        public int HotelId { get; set; }
        public string Code { get; set; }

        public string SystemId { get; set; }

        public int? LanguageId { get; set; }

        public int? ApiId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Type { get; set; }
    }

    public class HotelProductResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }

    public class Season
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("beginDate")]
        public DateTime BeginDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("textCategories")]
        public List<TextCategory> TextCategories { get; set; }

        [JsonProperty("facilityCategories")]
        public List<FacilityCategory> FacilityCategories { get; set; }

        [JsonProperty("mediaFiles")]
        public List<MediaFile> MediaFiles { get; set; }

        [JsonProperty("themes")]
        public List<Theme> Themes { get; set; }
    }

    public class TextCategory
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("presentations")]
        public List<Presentation> Presentations { get; set; }
    }

    public class Theme
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Town
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }




}