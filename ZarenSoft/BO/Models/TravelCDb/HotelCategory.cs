using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("HotelCategories", Schema = "dbo")]
    public partial class HotelCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public string SystemId { get; set; }

        [ConcurrencyCheck]
        public int? HotelId { get; set; }

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
        public string Code { get; set; }

        public Api Api { get; set; }

    }
}