using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("CancelationLanguages", Schema = "dbo")]
    public partial class CancelationLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CancelationRulesId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CancellationRule CancellationRule { get; set; }

        public Language Language { get; set; }

    }
}