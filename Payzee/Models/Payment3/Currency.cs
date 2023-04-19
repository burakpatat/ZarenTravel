using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payzee.Models.Payment3
{
    [Table("Currencies", Schema = "dbo")]
    public partial class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public string Number { get; set; }

        public bool? IsActive { get; set; }

        public int? TableOrder { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}