using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSiteSettingsEmailVoucher", Schema = "zaren")]
    public partial class AgencyMicroSiteSettingsEmailVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? SendBookingEmailFromAgency { get; set; }

        public bool? FromEmailAgency { get; set; }

        public bool? AvoidSendBookingMailToOperator { get; set; }

        public bool? HideCoverPageAndDayByDayPdf { get; set; }

        public bool? PrintPDFVoucherOneService { get; set; }

        public bool? ExcludePricesBookingsOnlinePDFVoucher { get; set; }

        public bool? SendMoAppEmailReminder { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

    }
}