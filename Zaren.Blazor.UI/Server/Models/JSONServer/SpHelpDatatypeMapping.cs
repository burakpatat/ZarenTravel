using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpHelpDatatypeMapping
    {
        public string sql_type { get; set; }

        public long? sql_len_min { get; set; }

        public long? sql_len_max { get; set; }

        public long? sql_prec_min { get; set; }

        public long? sql_prec_max { get; set; }

        public int? sql_scale_min { get; set; }

        public int? sql_scale_max { get; set; }

        public bool? sql_nullable { get; set; }

        public int? sql_createparams { get; set; }

        public string dest_type { get; set; }

        public long? dest_len { get; set; }

        public long? dest_prec { get; set; }

        public int? dest_scale { get; set; }

        public bool? dest_nullable { get; set; }

        public int? dest_createparams { get; set; }

        public bool? dataloss { get; set; }

    }
}