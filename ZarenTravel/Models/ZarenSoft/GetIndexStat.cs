using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetIndexStat
    {
        public string Database { get; set; }

        public string Table { get; set; }

        [Column("Index Name")]
        public string IndexName { get; set; }

        [Column("Index Type")]
        public string IndexType { get; set; }

        [Column("Avg Frag %")]
        public decimal? AvgFrag { get; set; }

        [Column("Row Ct")]
        public long? RowCt { get; set; }

        [Column("Stats Dt")]
        public string StatsDt { get; set; }

    }
}