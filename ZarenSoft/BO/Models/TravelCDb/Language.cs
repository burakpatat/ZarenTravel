using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Language", Schema = "dbo")]
    public partial class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string ShortCode { get; set; }

        [ConcurrencyCheck]
        public string Tr { get; set; }

        [ConcurrencyCheck]
        public string En { get; set; }

        [ConcurrencyCheck]
        public string De { get; set; }

        [ConcurrencyCheck]
        public string Fr { get; set; }

        [ConcurrencyCheck]
        public string Es { get; set; }

        [ConcurrencyCheck]
        public string It { get; set; }

        public ICollection<Country> Countries { get; set; }

    }
}