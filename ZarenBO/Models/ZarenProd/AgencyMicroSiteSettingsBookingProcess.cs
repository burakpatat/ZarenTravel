using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsBookingProcess", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsBookingProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public int? PaymentOption { get; set; }

        public int? AllowB2CUserInvoice { get; set; }

        public bool? RequireAgencyBookingProcess { get; set; }

        public bool? EnableCrossSellTicket { get; set; }

        public bool? EnableCrossSellRentalCars { get; set; }

        public bool? EnableCrossSellCrossSelling { get; set; }

        public bool? EnableCrossSellTransports { get; set; }

        public bool? EnableCrossSellTransfers { get; set; }

        public bool? NotifyChangesRequotingSavedIdea { get; set; }

        public decimal? MaxTolerancePrice { get; set; }

        public int? MaxToleranceAmountId { get; set; }

        public int? MaxToleranceCurrencyId { get; set; }

        public bool? B2BUsersManuelServicesEnable { get; set; }

        public bool? ShowFareBreakdownOnTransports { get; set; }

        public bool? SetFlightTaxesAsNonCommissionAble { get; set; }

        public int? DefaultReplicatorbookingmodeForB2B { get; set; }

        public int? DefaultReplicatorbookingmodeForB2C { get; set; }

        public int? SelectAppearDigitalBrochuresForB2BUsers { get; set; }

        public int? SelectAppearDigitalBrochuresForB2CUsers { get; set; }

        public bool? ForOnRequestContracts { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}