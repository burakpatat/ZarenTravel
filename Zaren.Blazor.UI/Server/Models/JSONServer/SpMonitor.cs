using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpMonitor
    {
        public DateTime last_run { get; set; }

        public DateTime? current_run { get; set; }

        public int? seconds { get; set; }

    }
}