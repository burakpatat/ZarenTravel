﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountLogins
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public string AccountAgent { get; set; }
        public string Token { get; set; }
        public bool? IsSuccessfull { get; set; }
        [Column("IPAddress")]
        public string Ipaddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiresIn { get; set; }
        [StringLength(3)]
        public string Language { get; set; }
        public long AccountDeviceId { get; set; }
    }
}