﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountCategory
    {
        [Key]
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        [StringLength(5)]
        public string Language { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        [StringLength(200)]
        public string Url { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public int? TableOrder { get; set; }
    }
}