using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProgrammingTechnologyGetByCodeFamilyName
    {
        public int Id { get; set; }

        public string CodeFamilyName { get; set; }

        public string CodeType { get; set; }

        public string IDE { get; set; }

    }
}