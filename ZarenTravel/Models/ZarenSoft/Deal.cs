using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Deals", Schema = "dbo")]
    public partial class Deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelRoomId { get; set; }

        public int? BoardTypeId { get; set; }

        public int? DealTypeId { get; set; }

        public int? Release { get; set; }

        public decimal? Discount { get; set; }

        public int? FreeNights { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<BookingDeal> BookingDeals { get; set; }

        public BoardType BoardType { get; set; }

        public DealType DealType { get; set; }

        public HotelRoom HotelRoom { get; set; }

    }
}