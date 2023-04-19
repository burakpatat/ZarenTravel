using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("Projects", Schema = "dbo")]
    public partial class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Name { get; set; }

        [Required]
        public string Guid { get; set; }

        public string Tables { get; set; }

        public string Configuration { get; set; }

        public string DatabaseSchemas { get; set; }

        public string RuleGroups { get; set; }

    }
}