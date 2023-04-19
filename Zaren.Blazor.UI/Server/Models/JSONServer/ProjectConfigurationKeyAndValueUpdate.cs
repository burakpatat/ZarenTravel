using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectConfigurationKeyAndValueUpdate
    {
        public int Id { get; set; }

        public string ConfigurationKey { get; set; }

        public string ConfigurationKeyFieldType { get; set; }

        public int? ConfigurationKeyFromInputType { get; set; }

        public string ConfigurationValue { get; set; }

        public int? ConfigurationValueType { get; set; }

        public int? ParentConfigurationKeyId { get; set; }

    }
}