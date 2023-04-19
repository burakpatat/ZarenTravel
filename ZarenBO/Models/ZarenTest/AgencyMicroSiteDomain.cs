using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteDomains", Schema = "dbo")]
    public partial class AgencyMicroSiteDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MicroSiteId { get; set; }

        public int? AgencyId { get; set; }

        public string DomainUrl { get; set; }

        public int? DefaultLanguageId { get; set; }

        public string DomainHostIP { get; set; }

        public string GtagId { get; set; }

        public string FacebookPixelId { get; set; }

        public string FacebookDomainVerification { get; set; }

        public string GoogleTagManagerId { get; set; }

        public string BingAds { get; set; }

        public string AdwordsId { get; set; }

        public string AdwordsLabel { get; set; }

        public string KayakPartnerCode { get; set; }

        public string TradeTrackerClientId { get; set; }

        public string VePixelId { get; set; }

        public string TradeTrackerProductOnlyAccommodation { get; set; }

        public string TradeTrackerPidOthers { get; set; }

        public string GoogleSiteVerification { get; set; }

        public string SiteMapJson { get; set; }

    }
}