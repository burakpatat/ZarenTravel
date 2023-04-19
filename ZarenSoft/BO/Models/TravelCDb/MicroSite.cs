using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("MicroSites", Schema = "dbo")]
    public partial class MicroSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public string Domain { get; set; }

        [ConcurrencyCheck]
        public string SubDomain { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreatedDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdatedBy { get; set; }

        [ConcurrencyCheck]
        public string RedirectUrl { get; set; }

        [ConcurrencyCheck]
        public string CollectivePassword { get; set; }

        [ConcurrencyCheck]
        public bool? HasAgencyManagementFee { get; set; }

        [ConcurrencyCheck]
        public string ContractFile { get; set; }

        public ICollection<AgencyManager> AgencyManagers { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<MicroSiteApiProvider> MicroSiteApiProviders { get; set; }

        public ICollection<MicrositeCountry> MicrositeCountries { get; set; }

        public ICollection<MicroSiteInvoice> MicroSiteInvoices { get; set; }

    }
}