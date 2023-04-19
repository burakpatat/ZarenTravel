using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AutoCompletes", Schema = "dbo")]
    public partial class AutoComplete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Type { get; set; }

        public int? ApiId { get; set; }

        public string SystemId { get; set; }

        public string SystemType { get; set; }

        public int? LanguageId { get; set; }

        public AutoCompleteType AutoCompleteType { get; set; }

    }
}