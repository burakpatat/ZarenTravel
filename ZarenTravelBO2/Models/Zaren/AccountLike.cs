using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AccountLikes", Schema = "dbo")]
    public partial class AccountLike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public int ProductType { get; set; }

        public bool? IsActive { get; set; }

        public string CookieId { get; set; }

    }
}