using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class TablesInsert
    {
        public long Id { get; set; }

        public long? ProjectId { get; set; }

        public string TableName { get; set; }

        public string Config { get; set; }

    }
}