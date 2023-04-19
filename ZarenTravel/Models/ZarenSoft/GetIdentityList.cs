using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetIdentityList
    {
        public string table_schema { get; set; }

        public string table_name { get; set; }

        public string column_Name { get; set; }

    }
}