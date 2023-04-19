using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Logs", Schema = "dbo")]
    public partial class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public int? Type { get; set; }

        public string LogPath { get; set; }

        public string LogMethod { get; set; }

        public int? UserID { get; set; }

        public string UserAgent { get; set; }

        public string UserHostAddress { get; set; }

        public string UrlOriginalString { get; set; }

    }
}