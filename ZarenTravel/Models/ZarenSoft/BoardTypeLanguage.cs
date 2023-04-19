using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("BoardTypeLanguages", Schema = "dbo")]
    public partial class BoardTypeLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? LanguageId { get; set; }

        public int? BoardTypeId { get; set; }

        public string Name { get; set; }

        public BoardType BoardType { get; set; }

        public Language Language { get; set; }

    }
}