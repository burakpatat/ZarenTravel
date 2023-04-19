using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("brands")]
    public class Brands
    {
        public int brand_id { get; set; }
        [Required]
        public string brand_name { get; set; }
    }
}

