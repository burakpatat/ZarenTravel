using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelBuyRoomAllotment", Schema = "dbo")]
    public partial class HotelBuyRoomAllotment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelBuyRoomId { get; set; }

        public DateTime? Day { get; set; }

        public int? Allotment { get; set; }

        public int? Release { get; set; }

        public int? StopSales { get; set; }

        public HotelBuyRoom HotelBuyRoom { get; set; }

    }
}