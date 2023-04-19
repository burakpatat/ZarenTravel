using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ExchangeRatesUpdate
    {
        public int Id { get; set; }

        public int? CurrencyIdFrom { get; set; }

        public int? CurrencyIdTo { get; set; }

        public decimal? ExRaValue { get; set; }

        public DateTime? ExRaDate { get; set; }

        public int? ExRaTimestamp { get; set; }

        public bool? ExRaActive { get; set; }

    }
}