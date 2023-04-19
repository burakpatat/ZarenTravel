using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("ApiProducts", Schema = "dbo")]
    public partial class ApiProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? ApiId { get; set; }

        public int? ProductType { get; set; }

    }
}