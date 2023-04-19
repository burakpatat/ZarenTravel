using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsHotelsConfiguration", Schema = "zaren")]
    public partial class AgencyContractsHotelsConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public int? ReleaseDay { get; set; }

        public byte? MinimumStay { get; set; }

        public int? MaximumStay { get; set; }

        public int? MinAgeStay { get; set; }

        public int? CurrencyId { get; set; }

        public int? SecurityDepositAmount { get; set; }

        public int? SecurityDepositCurrencyId { get; set; }

        public DateTime? CheckInDateFrom { get; set; }

        public DateTime? CheckInDateTo { get; set; }

        public DateTime? LateArrivalFrom { get; set; }

        public DateTime? LateArrivalTo { get; set; }

        public int? LateArrivalAmount { get; set; }

        public int? LateArrivalCurrencyId { get; set; }

        public int? CheckInDayId { get; set; }

        public DateTime? CheckOutUntil { get; set; }

        public DateTime? EarlyDepartureFrom { get; set; }

        public DateTime? EarlyDepartureTo { get; set; }

        public decimal? EarlyDepartureCostAmount { get; set; }

        public int? EarlyDepartureCostCurrencyId { get; set; }

        public int? CheckOutDayId { get; set; }

    }
}