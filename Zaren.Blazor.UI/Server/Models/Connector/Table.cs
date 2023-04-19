using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("Tables", Schema = "dbo")]
    public partial class Table
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public long? ProjectId { get; set; }

        public string TableName { get; set; }

        public string Config { get; set; }

    }
}