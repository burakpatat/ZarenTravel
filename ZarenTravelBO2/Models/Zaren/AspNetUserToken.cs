using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AspNetUserTokens", Schema = "zaren")]
    public partial class AspNetUserToken
    {
        public string Value { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string LoginProvider { get; set; }

        [Required]
        public string Name { get; set; }

    }
}