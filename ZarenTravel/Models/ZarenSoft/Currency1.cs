using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Currency", Schema = "dbo")]
    public partial class Currency1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyCodeIata { get; set; }

        public string CurrencyName { get; set; }

        public DateTime? CurrencyTimestamp { get; set; }

        public bool? CurrencyActive { get; set; }

        public ICollection<Air> Airs { get; set; }

        public ICollection<CarRent> CarRents { get; set; }

        public ICollection<Company> Companies { get; set; }

        public ICollection<ExchangeRate> ExchangeRates { get; set; }

        public ICollection<ExchangeRate> ExchangeRates1 { get; set; }

    }
}