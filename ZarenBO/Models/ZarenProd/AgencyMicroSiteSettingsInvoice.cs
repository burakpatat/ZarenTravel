using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsInvoice", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MicroSiteId { get; set; }

        public int? AgencyId { get; set; }

        public string NumberPrefix { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? Country { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string VAT { get; set; }

        public decimal? TaxesByPercentage { get; set; }

        public string BillingDetails { get; set; }

        public string BankDetails { get; set; }

        public string TaxesDetails { get; set; }

        public string LegalFooter { get; set; }

        public bool? DirectOperatorToAgencyBilling { get; set; }

        public string MailBody { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}