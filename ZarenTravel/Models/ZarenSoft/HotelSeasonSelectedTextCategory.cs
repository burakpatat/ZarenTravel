using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelSeasonSelectedTextCategories", Schema = "zaren")]
    public partial class HotelSeasonSelectedTextCategory
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? SeasonId { get; set; }

        public int? TextCategoriesId { get; set; }

        public int? LanguageId { get; set; }

        public int? ApiId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Type { get; set; }

    }
}