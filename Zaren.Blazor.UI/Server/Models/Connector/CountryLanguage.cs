using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("CountryLanguages", Schema = "dbo")]
    public partial class CountryLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CountryId { get; set; }

        public string CountryName { get; set; }

        public string LanguageName { get; set; }

    }
}