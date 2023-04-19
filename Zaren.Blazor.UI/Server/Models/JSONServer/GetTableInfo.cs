using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class GetTableInfo
    {
        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public string DbType { get; set; }

        public short MaxLength { get; set; }

        public string HasDefaultValue { get; set; }

        public bool? IsNullable { get; set; }

        public bool IsPrimary { get; set; }

        public string IndexDesc { get; set; }

        public string IndexName { get; set; }

        public int TableOrder { get; set; }

    }
}