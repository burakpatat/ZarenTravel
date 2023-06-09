﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class Accounts
    {
        public Accounts()
        {
            AccountProfileEncrypted = new HashSet<AccountProfileEncrypted>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Surname { get; set; }
        [StringLength(200)]
        public string AccountIcon { get; set; }
        [StringLength(200)]
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
        [StringLength(5)]
        public string Language { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? Guid { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<AccountProfileEncrypted> AccountProfileEncrypted { get; set; }
    }
}