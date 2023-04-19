using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Hotels", Schema = "dbo")]
    public partial class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelChainId { get; set; }

        public string Name { get; set; }

        public int? HotelTypeId { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public int? ZoneId { get; set; }

        public int? CityId { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int? CommercialContactId { get; set; }

        public int? ReservationContactId { get; set; }

        public int? FinanceContactId { get; set; }

        public int? Release { get; set; }

        public int? NumberRooms { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<CancellationSeason> CancellationSeasons { get; set; }

        public ICollection<FacilitiesHotel> FacilitiesHotels { get; set; }

        public ICollection<HotelAgencyMarkup> HotelAgencyMarkups { get; set; }

        public ICollection<HotelBuyRoom> HotelBuyRooms { get; set; }

        public ICollection<HotelDescription> HotelDescriptions { get; set; }

        public ICollection<HotelPhoto> HotelPhotos { get; set; }

        public City City { get; set; }

        public Contact Contact { get; set; }

        public Country Country { get; set; }

        public Contact Contact1 { get; set; }

        public HotelChain HotelChain { get; set; }

        public HotelType HotelType { get; set; }

        public Region Region { get; set; }

        public Contact Contact2 { get; set; }

        public Zone Zone { get; set; }

    }
}