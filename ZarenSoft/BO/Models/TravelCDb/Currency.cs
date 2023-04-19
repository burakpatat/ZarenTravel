using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Currency", Schema = "dbo")]
    public partial class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string CurrencyCode { get; set; }

        [ConcurrencyCheck]
        public string CurrencyCodeIata { get; set; }

        [ConcurrencyCheck]
        public string CurrencyName { get; set; }

        [ConcurrencyCheck]
        public DateTime? CurrencyTimestamp { get; set; }

        [ConcurrencyCheck]
        public bool? CurrencyActive { get; set; }

        public ICollection<AgencyUser> AgencyUsers { get; set; }

    }
}