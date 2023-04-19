using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgentInformation", Schema = "dbo")]
    public partial class AgentInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string AgentCode { get; set; }

        public string AgentName { get; set; }

        public string AgentStation { get; set; }

        public int? FILE_ID { get; set; }

        public string FILE_NAME { get; set; }

        public DateTime? RecordDateStamp { get; set; }

    }
}