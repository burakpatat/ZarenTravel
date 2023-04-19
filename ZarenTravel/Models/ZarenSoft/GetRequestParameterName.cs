using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetRequestParameterName
    {
        public string SPECIFIC_SCHEMA { get; set; }

        public string SPECIFIC_NAME { get; set; }

        public int ORDINAL_POSITION { get; set; }

        public string ROUTINE_TYPE { get; set; }

        public string RoutineResultDataType { get; set; }

        public string PARAMETER_NAME { get; set; }

        public int? ParameterDirection { get; set; }

        public string DDL_NAME { get; set; }

        public string TableDataType { get; set; }

    }
}