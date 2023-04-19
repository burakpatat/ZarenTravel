using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DynamicTableSearchTable
    {
        public string PrimaryKey { get; set; }

        public string ColumnName { get; set; }

        public string ColumnValue { get; set; }

    }
}