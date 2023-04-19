using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelPhotoLanguages", Schema = "dbo")]
    public partial class HotelPhotoLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelPhotoId { get; set; }

        public int? LanguageId { get; set; }

        public string Description { get; set; }

        public HotelPhoto HotelPhoto { get; set; }

        public Language Language { get; set; }

    }
}