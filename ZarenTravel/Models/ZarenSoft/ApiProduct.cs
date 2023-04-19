using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ApiProducts", Schema = "zaren")]
    public partial class ApiProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? ApiId { get; set; }

        public int? ProductType { get; set; }

    }
}