using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Agency", Schema = "dbo")]
    public partial class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Statu { get; set; }

        public int? AgencyManagerId { get; set; }

        public string InvoiceName { get; set; }

        public string City { get; set; }

        public int? Country { get; set; }

        public string WhatsAppNo { get; set; }

        public string Email { get; set; }

        public double? Taxes { get; set; }

        public int? ExternalId { get; set; }

        public string Address { get; set; }

        public string Provience { get; set; }

        public string DocumentNumber { get; set; }

        public string ContactPersonName { get; set; }

        public string BillingEmails { get; set; }

        public string BusinessName { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string PhoneNo { get; set; }

        public string ContactPersonLastName { get; set; }

        public string ManagementGroup { get; set; }

        public string Remarks { get; set; }

        public string WinterHours { get; set; }

        public string SummerHours { get; set; }

        public int? InvoiceTypeId { get; set; }

        public bool? DeferredPaymentAllowed { get; set; }

        public int? DeferredPaymentDays { get; set; }

        public decimal? DeferredPaymentLimit { get; set; }

        public int? DeferredPaymentLimitCurrency { get; set; }

        public int? MinimumFirstPaymentAmount { get; set; }

        public bool? MinimumFirstPaymentIsByPercentage { get; set; }

        public string GDSIdentifierForGalileo { get; set; }

        public bool? HasCreditOrDepositPaymentAllowed { get; set; }

        public AgencyManager AgencyManager { get; set; }

        public Country1 Country1 { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public ICollection<AgencyCmsSocialMediaUrl> AgencyCmsSocialMediaUrls { get; set; }

        public ICollection<AgencyCmsTheme> AgencyCmsThemes { get; set; }

        public ICollection<AgencyMicroSiteApiProductProvider> AgencyMicroSiteApiProductProviders { get; set; }

        public ICollection<AgencyMicroSiteDesign> AgencyMicroSiteDesigns { get; set; }

        public ICollection<AgencyMicroSiteDomainLanguageSetting> AgencyMicroSiteDomainLanguageSettings { get; set; }

        public ICollection<AgencyMicroSiteDomain> AgencyMicroSiteDomains { get; set; }

        public ICollection<AgencyMicroSitePaymentProvider> AgencyMicroSitePaymentProviders { get; set; }

        public ICollection<AgencyMicroSiteProperty> AgencyMicroSiteProperties { get; set; }

        public ICollection<AgencyMicroSite> AgencyMicroSites { get; set; }

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

        public ICollection<Language> Languages { get; set; }

    }
}