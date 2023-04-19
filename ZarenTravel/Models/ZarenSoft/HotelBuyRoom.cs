using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelBuyRooms", Schema = "dbo")]
    public partial class HotelBuyRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? BuyRoomId { get; set; }

        public ICollection<HotelBuyRoomAllotment> HotelBuyRoomAllotments { get; set; }

        public BuyRoom BuyRoom { get; set; }

        public Hotel Hotel { get; set; }

    }
}