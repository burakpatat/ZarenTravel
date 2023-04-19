﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfileInfo
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string PersonelInfo { get; set; }
        [StringLength(300)]
        public string Location { get; set; }
        [StringLength(300)]
        public string Website { get; set; }
        [StringLength(200)]
        public string CoverImage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        [StringLength(5)]
        public string Language { get; set; }
        [StringLength(300)]
        public string Title { get; set; }
    }
}