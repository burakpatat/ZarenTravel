using Zaren.Domain.Hotel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Shared.HotelModels
{
    public class HotelDetailDTO
    {
        public string HotelId { get; set; }
        public float stars { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public string locationName { get; set; }
        public List<Room> rooms { get; set; }
        public DateTime cancellationDueDate { get; set; }
        public double cancellationPrice { get; set; }
        public string cancellationCurrency { get; set; }
        public string offerId { get; set; }
        public DateTime offerCheckIn { get; set; }
        public Price price { get; set; }
        public HotelCategory hotelCategory { get; set; }
        public string thumbnail { get; set; }
        public string thumbnailFull { get; set; }
        public Description description { get; set; }
        public int travellernum { get; set; }
        public List<Theme> themes { get; set; }
        public List<Facility> facilities { get; set; }
        public List<MediaFiles> mediaFiles { get; set; }
        public List<OfferDetail> offerDetails { get; set; }
        public List<Season> seasons { get; set; }
    }
}
