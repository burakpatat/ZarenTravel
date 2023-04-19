using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class GetModifyDate
    {
        public string name { get; set; }

        public string type { get; set; }

        public DateTime create_date { get; set; }

        public DateTime modify_date { get; set; }

    }
}