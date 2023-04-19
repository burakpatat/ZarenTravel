using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DynamicTableSearchAll
    {
        public string PrimaryKey { get; set; }

        public string ColumnName { get; set; }

        public string ColumnValue { get; set; }

    }
}