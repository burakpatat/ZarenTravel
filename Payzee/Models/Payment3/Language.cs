using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payzee.Models.Payment3
{
    [Table("Languages", Schema = "dbo")]
    public partial class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string LanguageCode { get; set; }

        public ICollection<PaymentConfiguration> PaymentConfigurations { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}