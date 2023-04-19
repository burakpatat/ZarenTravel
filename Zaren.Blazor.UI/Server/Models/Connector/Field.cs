using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("Fields", Schema = "dbo")]
    public partial class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ColumnName { get; set; }

        public string DbType { get; set; }

        public string PrimitiveType { get; set; }

        public bool? IsNullable { get; set; }

        public int? MaxLength { get; set; }

        public string ConstraintRules { get; set; }

        public bool? IsPrimary { get; set; }

        public string Comment { get; set; }

        public string DefaultValue { get; set; }

        public string TableName { get; set; }

        public string ProjectName { get; set; }

        public long? TableId { get; set; }

        public long? ProjectId { get; set; }

    }
}