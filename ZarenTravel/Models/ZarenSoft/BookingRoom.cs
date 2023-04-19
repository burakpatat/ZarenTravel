using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("BookingRooms", Schema = "dbo")]
    public partial class BookingRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? BookingId { get; set; }

        public int? HotelRoomId { get; set; }

        public int? BoardTypeId { get; set; }

        public decimal? Cost { get; set; }

        public int? Price { get; set; }

        public BoardType BoardType { get; set; }

        public Booking Booking { get; set; }

        public HotelRoom HotelRoom { get; set; }

    }
}