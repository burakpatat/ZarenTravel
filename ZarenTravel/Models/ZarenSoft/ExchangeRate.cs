using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ExchangeRates", Schema = "dbo")]
    public partial class ExchangeRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CurrencyIdFrom { get; set; }

        public int? CurrencyIdTo { get; set; }

        public decimal? ExRaValue { get; set; }

        public DateTime? ExRaDate { get; set; }

        public int? ExRaTimestamp { get; set; }

        public bool? ExRaActive { get; set; }

        public Currency1 Currency1 { get; set; }

        public Currency1 Currency11 { get; set; }

    }
}