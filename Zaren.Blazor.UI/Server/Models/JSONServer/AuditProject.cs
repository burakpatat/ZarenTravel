using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditProjects", Schema = "dbo")]
    public partial class AuditProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public int? Id { get; set; }

        public int? UserId { get; set; }

        public string Name { get; set; }

        public string Guid { get; set; }

        public string Tables { get; set; }

        public string Configuration { get; set; }

        public string DatabaseSchemas { get; set; }

        public string RuleGroups { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}