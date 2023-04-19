using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("DealTypeLanguages", Schema = "dbo")]
    public partial class DealTypeLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? DealTypeId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DealType DealType { get; set; }

        public Language Language { get; set; }

    }
}