using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
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