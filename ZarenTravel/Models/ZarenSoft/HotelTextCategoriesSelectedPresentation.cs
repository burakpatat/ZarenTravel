using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelTextCategoriesSelectedPresentations", Schema = "zaren")]
    public partial class HotelTextCategoriesSelectedPresentation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelTextCategoriesId { get; set; }

        public int? PresentationId { get; set; }

        public int? LanguageId { get; set; }

        public int? ApiId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Type { get; set; }

    }
}