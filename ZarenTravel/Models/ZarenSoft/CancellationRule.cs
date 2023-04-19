using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("CancellationRules", Schema = "dbo")]
    public partial class CancellationRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CancellationSeasonId { get; set; }

        public decimal? Cost { get; set; }

        public int? CostType { get; set; }

        public int? FromDays { get; set; }

        public int? ToDays { get; set; }

        public ICollection<CancelationLanguage> CancelationLanguages { get; set; }

        public CancellationSeason CancellationSeason { get; set; }

    }
}