using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Cities", Schema = "dbo")]
    public partial class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public decimal? Latitude { get; set; }

        [ConcurrencyCheck]
        public decimal? Longitude { get; set; }

        [ConcurrencyCheck]
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<MicroSiteInvoice> MicroSiteInvoices { get; set; }

    }
}