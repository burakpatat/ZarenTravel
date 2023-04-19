using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("Languages", Schema = "dbo")]
    public partial class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string LanguageCode { get; set; }

        public int? TableOrder { get; set; }

        public string Icon { get; set; }

        public bool? IsDefault { get; set; }

        public bool? IsRTL { get; set; }

        public string CultureInfo { get; set; }

        public ICollection<PaymentConfiguration> PaymentConfigurations { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}