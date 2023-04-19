using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("FacilityLanguages", Schema = "dbo")]
    public partial class FacilityLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? FacilityId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public Facility Facility { get; set; }

        public Language Language { get; set; }

    }
}