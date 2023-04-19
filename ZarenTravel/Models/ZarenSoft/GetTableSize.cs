using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetTableSize
    {
        public string name { get; set; }

        public string TableName { get; set; }

        public long? RowCounts { get; set; }

        public long? TotalSpaceKB { get; set; }

        public string TotalSpaceKB_Swiss { get; set; }

        public long? UsedSpaceKB { get; set; }

        public long? UnusedSpaceKB { get; set; }

    }
}