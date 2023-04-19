using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DynamicTableCount
    {
        public string schema_name { get; set; }

        public string table_name { get; set; }

        public int? columns { get; set; }

    }
}