using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteSettingsOther", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsOther
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? AskForIdAndBirthdate { get; set; }

        public bool? IdeaBrochureIndexing { get; set; }

        public bool? ShowTotalPriceInBrochure { get; set; }

        public bool? ShowImagePaymentMethodInFooter { get; set; }

        public bool? PendingPaymentAutoCancellation { get; set; }

        public bool? ShowWhatsAppGetButton { get; set; }

        public string WhatsAppNumber { get; set; }

        public bool? ShowAgencyIdInDropdownInsteadOfAgencyName { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

    }
}