using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ConstraintRulesGetByAddWithNoCheck
    {
        public long Id { get; set; }

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

    }
}