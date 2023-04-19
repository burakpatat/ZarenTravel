using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ForeignKeyRulesGetByReferencedColumnName
    {
        public long Id { get; set; }

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

    }
}