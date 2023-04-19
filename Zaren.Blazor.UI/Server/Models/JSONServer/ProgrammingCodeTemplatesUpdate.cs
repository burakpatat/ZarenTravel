using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProgrammingCodeTemplatesUpdate
    {
        public int Id { get; set; }

        public int? ProgrammingLanguage { get; set; }

        public string Template { get; set; }

        public string ReplacedFields { get; set; }

    }
}