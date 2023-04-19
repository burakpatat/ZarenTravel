using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelTypeLanguages", Schema = "dbo")]
    public partial class HotelTypeLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelTypeId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public HotelType HotelType { get; set; }

        public Language Language { get; set; }

    }
}