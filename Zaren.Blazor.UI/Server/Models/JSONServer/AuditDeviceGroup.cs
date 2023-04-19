using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditDeviceGroups", Schema = "dbo")]
    public partial class AuditDeviceGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}