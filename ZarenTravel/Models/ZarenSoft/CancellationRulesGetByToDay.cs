using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CancellationRulesGetByToDay
    {
        public int Id { get; set; }

        public int? CancellationSeasonId { get; set; }

        public decimal? Cost { get; set; }

        public int? CostType { get; set; }

        public int? FromDays { get; set; }

        public int? ToDays { get; set; }

    }
}