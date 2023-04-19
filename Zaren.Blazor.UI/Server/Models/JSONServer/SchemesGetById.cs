using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SchemesGetById
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int? DatabaseType { get; set; }

        public string ProjectCategoryId { get; set; }

        public bool? IsFavorite { get; set; }

        public string ConfigurationSettings { get; set; }

        public int? CountryLanguageId { get; set; }

        public bool? CanBeTranslate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}