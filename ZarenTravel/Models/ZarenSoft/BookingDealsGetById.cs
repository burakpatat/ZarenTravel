using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class BookingDealsGetById
    {
        public int Id { get; set; }

        public int? BookingId { get; set; }

        public int? DealId { get; set; }

    }
}