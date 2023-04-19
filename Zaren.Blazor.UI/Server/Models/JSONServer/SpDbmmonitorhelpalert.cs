using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpDbmmonitorhelpalert
    {
        public string database_name { get; set; }

        public int? threshold { get; set; }

        public bool? enabled { get; set; }

    }
}