using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditProjectConfigurationKeyAndValue", Schema = "dbo")]
    public partial class AuditProjectConfigurationKeyAndValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public int? Id { get; set; }

        public string ConfigurationKey { get; set; }

        public string ConfigurationKeyFieldType { get; set; }

        public int? ConfigurationKeyFromInputType { get; set; }

        public string ConfigurationValue { get; set; }

        public int? ConfigurationValueType { get; set; }

        public int? ParentConfigurationKeyId { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}