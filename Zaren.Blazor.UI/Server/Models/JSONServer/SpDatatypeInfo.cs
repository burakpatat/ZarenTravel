using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpDatatypeInfo
    {
        public string TYPE_NAME { get; set; }

        public short? DATA_TYPE { get; set; }

        public int? PRECISION { get; set; }

        public string LITERAL_PREFIX { get; set; }

        public string LITERAL_SUFFIX { get; set; }

        public string CREATE_PARAMS { get; set; }

        public short? NULLABLE { get; set; }

        public short? CASE_SENSITIVE { get; set; }

        public short SEARCHABLE { get; set; }

        public short? UNSIGNED_ATTRIBUTE { get; set; }

        public short MONEY { get; set; }

        public short? AUTO_INCREMENT { get; set; }

        public string LOCAL_TYPE_NAME { get; set; }

        public short? MINIMUM_SCALE { get; set; }

        public short? MAXIMUM_SCALE { get; set; }

        public short? SQL_DATA_TYPE { get; set; }

        public short? SQL_DATETIME_SUB { get; set; }

        public int? NUM_PREC_RADIX { get; set; }

        public short? INTERVAL_PRECISION { get; set; }

        public short? USERTYPE { get; set; }

    }
}