using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CarRentsGetByCaTyId
    {
        public int Id { get; set; }

        public int? PNRId { get; set; }

        public int? CaTyId { get; set; }

        public int? CaRtId { get; set; }

        public int? AirportIdPickUp { get; set; }

        public int? AirportIdReturn { get; set; }

        public DateTime? CaRePickUpDate { get; set; }

        public DateTime? CaReReturnDate { get; set; }

        public decimal? CaReRate { get; set; }

        public decimal? CaReTax { get; set; }

        public int? CurrencyId { get; set; }

        public DateTime? CaReBookDate { get; set; }

        public DateTime? CaReTimestamp { get; set; }

        public bool? CaReActive { get; set; }

    }
}