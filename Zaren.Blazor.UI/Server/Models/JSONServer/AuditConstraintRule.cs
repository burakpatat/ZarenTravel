using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditConstraintRules", Schema = "dbo")]
    public partial class AuditConstraintRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public long? Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string CheckConstraint { get; set; }

        public string AddWithCheck { get; set; }

        public string AddWithNoCheck { get; set; }

        public long? ColumnId { get; set; }

        public string TableName { get; set; }

        public string ProjectName { get; set; }

        public long? TableId { get; set; }

        public long? ProjectId { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}