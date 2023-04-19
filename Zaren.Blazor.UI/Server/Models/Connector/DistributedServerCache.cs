using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("DistributedServerCache", Schema = "dbo")]
    public partial class DistributedServerCache
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public byte[] Value { get; set; }

        [Required]
        public DateTimeOffset ExpiresAtTime { get; set; }

        public long? SlidingExpirationInSeconds { get; set; }

        public DateTimeOffset? AbsoluteExpiration { get; set; }

    }
}