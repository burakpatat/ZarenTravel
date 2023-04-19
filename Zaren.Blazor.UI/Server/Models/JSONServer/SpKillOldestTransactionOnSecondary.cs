using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class SpKillOldestTransactionOnSecondaryResult
    {
        public long? killed_xdests { get; set; }

        public int returnValue { get; set; }

    }
}