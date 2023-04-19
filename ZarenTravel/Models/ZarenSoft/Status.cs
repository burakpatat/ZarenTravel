using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Status", Schema = "dbo")]
    public partial class Status
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Name { get; set; }

    }
}