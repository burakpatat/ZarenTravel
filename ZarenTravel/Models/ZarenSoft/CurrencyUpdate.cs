using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CurrencyUpdate
    {
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyCodeIata { get; set; }

        public string CurrencyName { get; set; }

        public DateTime? CurrencyTimestamp { get; set; }

        public bool? CurrencyActive { get; set; }

    }
}