using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class GetTableColumn
    {
        public string TABLE_SCHEMA { get; set; }

        public string TABLE_NAME { get; set; }

        public string COLUMN_NAME { get; set; }

        public int? ORDINAL_POSITION { get; set; }

        public string IS_NULLABLE { get; set; }

        public string DATA_TYPE { get; set; }

        public bool is_identity { get; set; }

        public bool IS_COMPUTED { get; set; }

        public bool? IS_PERSISTED { get; set; }

        public string COMPUTATION { get; set; }

        public int? CHARACTER_MAXIMUM_LENGTH { get; set; }

        public int? CHARACTER_OCTET_LENGTH { get; set; }

        public byte? NUMERIC_PRECISION { get; set; }

        public int? NUMERIC_SCALE { get; set; }

        public short? DATETIME_PRECISION { get; set; }

        public string DDL_NAME { get; set; }

        public string name { get; set; }

        public string definition { get; set; }

    }
}