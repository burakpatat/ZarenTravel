using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditTables", Schema = "dbo")]
    public partial class AuditTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public long? Id { get; set; }

        public long? ProjectId { get; set; }

        public string TableName { get; set; }

        public string Config { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}