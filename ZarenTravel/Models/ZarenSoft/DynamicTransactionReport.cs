using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DynamicTransactionReport
    {
        public DateTime CurrentTime { get; set; }

        public string LoginName { get; set; }

        public string DatabaseName { get; set; }

        [Column("Transactio BeginTime")]
        public DateTime? TransactioBeginTime { get; set; }

        public long LogUsedBytes { get; set; }

        public long LogReservedBytes { get; set; }

        public string QueryText { get; set; }

    }
}