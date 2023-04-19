using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DynamicTableForeignKey
    {
        public string table_schema_name { get; set; }

        public string table_name { get; set; }

        public string column_name { get; set; }

        public string constraint_name { get; set; }

        public string primary_table_schema_name { get; set; }

        public string primary_table_name { get; set; }

        public string primary_table_column { get; set; }

        public string join_condition { get; set; }

        public string complex_fk { get; set; }

        public int fk_part { get; set; }

    }
}