using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetSpLog
    {
        public string sql { get; set; }

        public string SPECIFIC_SCHEMA { get; set; }

        public string SPECIFIC_NAME { get; set; }

    }
}