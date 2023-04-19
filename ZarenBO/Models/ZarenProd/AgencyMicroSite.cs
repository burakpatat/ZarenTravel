using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSites", Schema = "dbo")]
    public partial class AgencyMicroSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public string Domain { get; set; }

        public string SubDomain { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public string RedirectUrl { get; set; }

        public string CollectivePassword { get; set; }

        public ICollection<AgencyManager> AgencyManagers { get; set; }

        public ICollection<AgencyMicroSiteApiProductProvider> AgencyMicroSiteApiProductProviders { get; set; }

        public ICollection<AgencyMicroSiteDomainLanguageSetting> AgencyMicroSiteDomainLanguageSettings { get; set; }

        public ICollection<AgencyMicroSiteDomain> AgencyMicroSiteDomains { get; set; }

        public ICollection<AgencyMicroSitePaymentProvider> AgencyMicroSitePaymentProviders { get; set; }

        public Agency Agency { get; set; }

        public ICollection<AgencyMicroSiteSettingPassengerDatum> AgencyMicroSiteSettingPassengerData { get; set; }

        public ICollection<AgencyMicroSiteSettingsBookingProcess> AgencyMicroSiteSettingsBookingProcesses { get; set; }

        public ICollection<AgencyMicroSiteSettingsEmailVoucher> AgencyMicroSiteSettingsEmailVouchers { get; set; }

        public ICollection<AgencyMicroSiteSettingsGeneral> AgencyMicroSiteSettingsGenerals { get; set; }

        public ICollection<AgencyMicroSiteSettingsHelpSupport> AgencyMicroSiteSettingsHelpSupports { get; set; }

        public ICollection<AgencyMicroSiteSettingsInvoice> AgencyMicroSiteSettingsInvoices { get; set; }

        public ICollection<AgencyMicroSiteSettingsOther> AgencyMicroSiteSettingsOthers { get; set; }

        public ICollection<AgencyMicroSiteSettingsSearchEngine> AgencyMicroSiteSettingsSearchEngines { get; set; }

        public ICollection<AgencyMicroSiteSettingsSearchSetting> AgencyMicroSiteSettingsSearchSettings { get; set; }

        public ICollection<AgencyMicroSiteSettingsTermsCondition> AgencyMicroSiteSettingsTermsConditions { get; set; }

        public ICollection<AgencyMicroSitesSettingsEmailConfiguration> AgencyMicroSitesSettingsEmailConfigurations { get; set; }

    }
}