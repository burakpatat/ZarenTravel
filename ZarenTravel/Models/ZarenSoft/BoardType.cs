using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("BoardTypes", Schema = "dbo")]
    public partial class BoardType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BoardTypeLanguage> BoardTypeLanguages { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; }

        public ICollection<Deal> Deals { get; set; }

        public ICollection<HotelRoomDailyPrice> HotelRoomDailyPrices { get; set; }

    }
}