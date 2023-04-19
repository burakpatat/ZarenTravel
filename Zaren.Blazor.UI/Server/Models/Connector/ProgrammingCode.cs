using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("ProgrammingCodes", Schema = "dbo")]
    public partial class ProgrammingCode
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? LanguageType { get; set; }

        public string Code { get; set; }

        public int? TargetLanguageType { get; set; }

        public string TargetLanguageCode { get; set; }

        public string ExampleCodes { get; set; }

    }
}