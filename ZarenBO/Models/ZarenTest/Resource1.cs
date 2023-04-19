using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Resources", Schema = "zaren")]
    public partial class Resource1
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string LanguageCode { get; set; }

        public string ResourceKey { get; set; }

        public string ResourceValue { get; set; }

    }
}