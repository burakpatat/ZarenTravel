using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AspNetRoles", Schema = "zaren")]
    public partial class AspNetRole
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        public ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

    }
}