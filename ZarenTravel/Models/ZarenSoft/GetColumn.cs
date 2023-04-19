using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetColumn
    {
        public string TABLE_NAME { get; set; }

        public string COLUMN_NAME { get; set; }

        public int? ORDINAL_POSITION { get; set; }

        public string SQL_TYPE { get; set; }

        public string COLUMN_DEFAULT { get; set; }

        public string DOTNET_TYPE { get; set; }

        public int IS_REQUIRED { get; set; }

        public int? MAX_LENGTH { get; set; }

        public string COLUMN_TYPE { get; set; }

    }
}