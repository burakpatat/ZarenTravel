using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payzee.Models.Payment3
{
    [Table("Resources", Schema = "dbo")]
    public partial class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SourceKey { get; set; }

        public int? LanguageId { get; set; }

        public string SourceValue { get; set; }

        public Language Language { get; set; }

    }
}