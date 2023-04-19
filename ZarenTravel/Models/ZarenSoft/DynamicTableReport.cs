using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DynamicTableReport
    {
        public string schema_name { get; set; }

        public string table_name { get; set; }

        public DateTime created { get; set; }

        public DateTime last_modified { get; set; }

        public long? num_rows { get; set; }

        public object comments { get; set; }

    }
}