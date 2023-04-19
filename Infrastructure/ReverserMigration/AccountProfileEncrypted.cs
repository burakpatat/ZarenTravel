﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfileEncrypted
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public int? Currency { get; set; }
        [StringLength(200)]
        public string GoogleId { get; set; }
        [StringLength(200)]
        public string AppleId { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("AccountProfileEncrypted")]
        public virtual Accounts Account { get; set; }
    }
}