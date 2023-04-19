using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsTermsConditions", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsTermsCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? PackageTerms { get; set; }

        public bool? VisaTerms { get; set; }

        public bool? GDPRCheckBoxes { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}