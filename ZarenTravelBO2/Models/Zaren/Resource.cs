using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("Resources", Schema = "dbo")]
    public partial class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LanguageCode { get; set; }

        public string ResourceKey { get; set; }

        public string ResourceValue { get; set; }

    }
}