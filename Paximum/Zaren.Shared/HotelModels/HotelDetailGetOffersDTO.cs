using Zaren.Domain.Hotel;
using System;
using System.Collections.Generic;
using System.Text;


    namespace Zaren.Shared.HotelModels
    {
        public class HotelDetailGetOffersDTO
        {
            public string HotelId { get; set; }
            public float stars { get; set; }
            public string name { get; set; }
            public Zaren.Domain.Hotel.getoffersDetails.Address address { get; set; }
            public double rating { get; set; }
            public string locationName { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.Offer> offers { get; set; }
            public DateTime cancellationDueDate { get; set; }
            public double cancellationPrice { get; set; }
            public string cancellationCurrency { get; set; }
            public string offerId { get; set; }
            public DateTime offerCheckIn { get; set; }
            public Zaren.Domain.Hotel.getoffersDetails.Price price { get; set; }
            public Zaren.Domain.Hotel.getoffersDetails.HotelCategory hotelCategory { get; set; }
            public string thumbnail { get; set; }
            public string thumbnailFull { get; set; }
            public Zaren.Domain.Hotel.getoffersDetails.Description description { get; set; }
            public int travellernum { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.Theme> themes { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.Facility> facilities { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.MediaFiles> mediaFiles { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.OfferDetail> offerDetails { get; set; }
            public List<Zaren.Domain.Hotel.getoffersDetails.Season> seasons { get; set; }
        public List<Zaren.Domain.Hotel.getoffersDetails.Room> rooms { get; set; }
        }
    }
  

