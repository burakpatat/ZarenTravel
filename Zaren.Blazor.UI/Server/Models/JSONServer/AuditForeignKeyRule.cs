using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditForeignKeyRules", Schema = "dbo")]
    public partial class AuditForeignKeyRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public long? Id { get; set; }

        public string ColumnName { get; set; }

        public string ReferencedTableName { get; set; }

        public string ReferencedColumnName { get; set; }

        public string ReferencedColumnDbTypeCompare { get; set; }

        public int? DeleteRule { get; set; }

        public int? UpdateRule { get; set; }

        public string TableName { get; set; }

        public string ProjectName { get; set; }

        public long? ConstraintId { get; set; }

        public long? ColumnId { get; set; }

        public long? ProjectId { get; set; }

        public long? TableId { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}