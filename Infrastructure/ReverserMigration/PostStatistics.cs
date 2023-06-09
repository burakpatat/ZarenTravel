﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class PostStatistics
    {
        [Key]
        public long Id { get; set; }
        public long PostId { get; set; }
        public long? ViewCount { get; set; }
        public long? LikeCount { get; set; }
        public long? ShareToolClickCount { get; set; }
        public bool? IsNews { get; set; }
        public bool? IsPopular { get; set; }
        public bool? IsTrend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastScanDate { get; set; }
        public int? CommentCount { get; set; }
    }
}