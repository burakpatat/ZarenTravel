using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Agency", Schema = "dbo")]
    public partial class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? Statu { get; set; }

        [ConcurrencyCheck]
        public int? AgencyManagerId { get; set; }

        [ConcurrencyCheck]
        public string City { get; set; }

        [ConcurrencyCheck]
        public int? CountryId { get; set; }

        [ConcurrencyCheck]
        public string WhatsAppNo { get; set; }

        [ConcurrencyCheck]
        public string Email { get; set; }

        [ConcurrencyCheck]
        public double? Taxes { get; set; }

        [ConcurrencyCheck]
        public int? ExternalId { get; set; }

        [ConcurrencyCheck]
        public string Address { get; set; }

        [ConcurrencyCheck]
        public string Provience { get; set; }

        [ConcurrencyCheck]
        public string DocumentNumber { get; set; }

        [ConcurrencyCheck]
        public string ContactPersonName { get; set; }

        [ConcurrencyCheck]
        public string BillingEmails { get; set; }

        [ConcurrencyCheck]
        public string BusinessName { get; set; }

        [ConcurrencyCheck]
        public string PostalCode { get; set; }

        [ConcurrencyCheck]
        public string Region { get; set; }

        [ConcurrencyCheck]
        public string PhoneNo { get; set; }

        [ConcurrencyCheck]
        public string ContactPersonLastName { get; set; }

        [ConcurrencyCheck]
        public string ManagementGroup { get; set; }

        [ConcurrencyCheck]
        public string Remarks { get; set; }

        [ConcurrencyCheck]
        public string WinterHours { get; set; }

        [ConcurrencyCheck]
        public string SummerHours { get; set; }

        [ConcurrencyCheck]
        public int? InvoiceTypeId { get; set; }

        [ConcurrencyCheck]
        public bool? DeferredPaymentAllowed { get; set; }

        [ConcurrencyCheck]
        public int? DeferredPaymentDays { get; set; }

        [ConcurrencyCheck]
        public decimal? DeferredPaymentLimit { get; set; }

        [ConcurrencyCheck]
        public int? DeferredPaymentLimitCurrency { get; set; }

        [ConcurrencyCheck]
        public int? MinimumFirstPaymentAmount { get; set; }

        [ConcurrencyCheck]
        public bool? MinimumFirstPaymentIsByPercentage { get; set; }

        [ConcurrencyCheck]
        public string GDSIdentifierForGalileo { get; set; }

        [ConcurrencyCheck]
        public bool? HasCreditOrDepositPaymentAllowed { get; set; }

        public AgencyManager AgencyManager { get; set; }

        public Country Country { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public Statu Statu1 { get; set; }

        public ICollection<AgencyUser> AgencyUsers { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<MicroSiteApiProvider> MicroSiteApiProviders { get; set; }

        public ICollection<MicrositeCountry> MicrositeCountries { get; set; }

        public ICollection<MicroSiteInvoice> MicroSiteInvoices { get; set; }

    }
}