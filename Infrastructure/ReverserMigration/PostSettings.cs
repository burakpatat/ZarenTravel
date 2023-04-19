﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class PostSettings
    {
        [Key]
        public long Id { get; set; }
        public long PostId { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public bool? IsOpenToComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublishedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsStatu { get; set; }
        [StringLength(300)]
        public string Url { get; set; }
        [StringLength(50)]
        public string PostTags { get; set; }
        [StringLength(50)]
        public string PostCategory { get; set; }
    }
}