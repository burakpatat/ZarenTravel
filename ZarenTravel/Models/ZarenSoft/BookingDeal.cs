using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("BookingDeals", Schema = "dbo")]
    public partial class BookingDeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? BookingId { get; set; }

        public int? DealId { get; set; }

        public Booking Booking { get; set; }

        public Deal Deal { get; set; }

    }
}