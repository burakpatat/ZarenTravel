using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsClosedTours", Schema = "zaren")]
    public partial class AgencyContractsClosedTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public bool? IsSelect { get; set; }

        public bool? IsActive { get; set; }

        public bool? MarketPlace { get; set; }

        public bool? Pro { get; set; }

        public bool? Extension { get; set; }

        public string Code { get; set; }

        public string Creator { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? LastUpdate { get; set; }

        public DateTime? UpdateBy { get; set; }

        public string Supplier { get; set; }

        public string TourSupplierName { get; set; }

        public string Destinations { get; set; }

        public int? Nights { get; set; }

        public string ContractaFrom { get; set; }

        public string ContractTo { get; set; }

    }
}