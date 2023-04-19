using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpColumn
    {
        public string TABLE_QUALIFIER { get; set; }

        public string TABLE_OWNER { get; set; }

        public string TABLE_NAME { get; set; }

        public string COLUMN_NAME { get; set; }

        public short? DATA_TYPE { get; set; }

        public string TYPE_NAME { get; set; }

        public int? PRECISION { get; set; }

        public int? LENGTH { get; set; }

        public short? SCALE { get; set; }

        public short? RADIX { get; set; }

        public short? NULLABLE { get; set; }

        public string REMARKS { get; set; }

        public string COLUMN_DEF { get; set; }

        public short? SQL_DATA_TYPE { get; set; }

        public short? SQL_DATETIME_SUB { get; set; }

        public int? CHAR_OCTET_LENGTH { get; set; }

        public int? ORDINAL_POSITION { get; set; }

        public string IS_NULLABLE { get; set; }

        public byte? SS_DATA_TYPE { get; set; }

    }
}