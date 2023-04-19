using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("MicrositeCountries", Schema = "dbo")]
    public partial class MicrositeCountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public int? MicroSiteId { get; set; }

        [ConcurrencyCheck]
        public string Code { get; set; }

        [ConcurrencyCheck]
        public string Flag { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Continent { get; set; }

        [ConcurrencyCheck]
        public string Prefix { get; set; }

        [ConcurrencyCheck]
        public int? FarudRiskId { get; set; }

        [ConcurrencyCheck]
        public bool? ManualRegistration { get; set; }

        [ConcurrencyCheck]
        public int? DefaultCurrencyId { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreateDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatDate { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdateBy { get; set; }

        public Agency Agency { get; set; }

        public MicroSite MicroSite { get; set; }

    }
}