using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DynamicSpaceReport
    {
        public int ObjectID { get; set; }

        public string ObjectName { get; set; }

        public long? Total_Reserved_kb { get; set; }

        public long? Used_Space_kb { get; set; }

        public string TypeDesc { get; set; }

        public long? RowsCount { get; set; }

    }
}