using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("HotelFacilities", Schema = "dbo")]
    public partial class HotelFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public string SystemId { get; set; }

        [ConcurrencyCheck]
        public int? LanguageId { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreatedDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdatedBy { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Note { get; set; }

        [ConcurrencyCheck]
        public int? IsPriced { get; set; }

        [ConcurrencyCheck]
        public bool? Highlighted { get; set; }

        [ConcurrencyCheck]
        public int? Type { get; set; }

    }
}