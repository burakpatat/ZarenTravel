using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("MicroSiteCountriesFraudRisk", Schema = "dbo")]
    public partial class MicroSiteCountriesFraudRisk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string FraudRiskName { get; set; }

        public ICollection<Country> Countries { get; set; }

    }
}