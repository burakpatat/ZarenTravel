using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DynamicSpaceReport
    {
        public int ObjectID { get; set; }

        public string ObjectName { get; set; }

        public long? Total_Reserved_kb { get; set; }

        public long? Used_Space_kb { get; set; }

        public string TypeDesc { get; set; }

        public long? RowsCount { get; set; }

    }
}