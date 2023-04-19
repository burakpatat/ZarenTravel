using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelRoomDailyPrices", Schema = "dbo")]
    public partial class HotelRoomDailyPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? BoardTypeId { get; set; }

        public int? HotelRoomId { get; set; }

        public int? Cost { get; set; }

        public DateTime? Day { get; set; }

        public int? StopSale { get; set; }

        public BoardType BoardType { get; set; }

        public HotelRoom HotelRoom { get; set; }

    }
}