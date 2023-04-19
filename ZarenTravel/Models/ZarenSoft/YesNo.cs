using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("YesNo", Schema = "dbo")]
    public partial class YesNo
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Name { get; set; }

    }
}