using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelRooms", Schema = "dbo")]
    public partial class HotelRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelBuyRoomId { get; set; }

        public int? RoomId { get; set; }

        public string Name { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }

        public int? Infants { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; }

        public ICollection<Deal> Deals { get; set; }

        public ICollection<FacilitiesHotel> FacilitiesHotels { get; set; }

        public ICollection<HotelPhoto> HotelPhotos { get; set; }

        public ICollection<HotelRoomDailyPrice> HotelRoomDailyPrices { get; set; }

        public ICollection<HotelRoomLanguage> HotelRoomLanguages { get; set; }

        public Room Room { get; set; }

    }
}