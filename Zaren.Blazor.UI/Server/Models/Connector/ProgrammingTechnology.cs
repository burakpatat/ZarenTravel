using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.Connector
{
    [Table("ProgrammingTechnology", Schema = "dbo")]
    public partial class ProgrammingTechnology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CodeFamilyName { get; set; }

        public string CodeType { get; set; }

        public string IDE { get; set; }

    }
}