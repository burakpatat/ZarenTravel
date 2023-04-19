using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AspNetUserRoles", Schema = "zaren")]
    public partial class AspNetUserRole
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Key]
        [Required]
        public string RoleId { get; set; }

        public AspNetRole AspNetRole { get; set; }

        public AspNetUser AspNetUser { get; set; }

    }
}