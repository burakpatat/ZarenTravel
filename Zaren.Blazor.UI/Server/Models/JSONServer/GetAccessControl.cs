using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class GetAccessControl
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public bool? IsSystemObject { get; set; }

        public bool? IsAccessible { get; set; }

    }
}