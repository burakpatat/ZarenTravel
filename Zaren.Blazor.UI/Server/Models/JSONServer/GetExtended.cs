using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class GetExtended
    {
        public string Schema { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public string type_desc { get; set; }

        public string Name { get; set; }

        public object Value { get; set; }

    }
}