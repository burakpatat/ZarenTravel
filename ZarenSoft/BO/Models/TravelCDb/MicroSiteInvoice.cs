using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("MicroSiteInvoices", Schema = "dbo")]
    public partial class MicroSiteInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public int? MicroSiteId { get; set; }

        [ConcurrencyCheck]
        public string NumberPrefix { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Address { get; set; }

        [ConcurrencyCheck]
        public int? CountryId { get; set; }

        [ConcurrencyCheck]
        public string Email { get; set; }

        [ConcurrencyCheck]
        public int? CityId { get; set; }

        [ConcurrencyCheck]
        public string VAT { get; set; }

        [ConcurrencyCheck]
        public decimal? TaxesByPercentage { get; set; }

        [ConcurrencyCheck]
        public string BillingDetails { get; set; }

        [ConcurrencyCheck]
        public string BankDetails { get; set; }

        [ConcurrencyCheck]
        public string TaxesDetails { get; set; }

        [ConcurrencyCheck]
        public string LegalFooter { get; set; }

        [ConcurrencyCheck]
        public bool? DirectOperatorToAgencyBilling { get; set; }

        [ConcurrencyCheck]
        public string MailBody { get; set; }

        public Agency Agency { get; set; }

        public City City { get; set; }

        public Country Country { get; set; }

        public MicroSite MicroSite { get; set; }

    }
}