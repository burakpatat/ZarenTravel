using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DynamicViewDto
    {
        public string schema_name { get; set; }

        public string view_name { get; set; }

        public string column_name { get; set; }

        public string data_type { get; set; }

        public string data_type_ext { get; set; }

        public string nullable { get; set; }

        public object comments { get; set; }

    }
}