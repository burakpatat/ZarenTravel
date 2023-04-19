using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AirExtras", Schema = "dbo")]
    public partial class AirExtra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AirId { get; set; }

        public int? ExTyId { get; set; }

        public string AiExDescription { get; set; }

        public decimal? AiExFare { get; set; }

        public DateTime? AiExTimestamp { get; set; }

        public bool? AiExActive { get; set; }

        public Air Air { get; set; }

        public ExtrasType ExtrasType { get; set; }

    }
}