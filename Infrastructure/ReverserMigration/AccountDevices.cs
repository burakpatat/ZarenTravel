﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountDevices
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        [Column("IP")]
        [StringLength(50)]
        public string Ip { get; set; }
        public string AccountAgent { get; set; }
        [StringLength(100)]
        public string DeviceName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? CountryId { get; set; }
    }
}