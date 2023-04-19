﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    [Keyless]
    public partial class PostDetail
    {
        public long Id { get; set; }
        [StringLength(200)]
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public bool? IsViewable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(200)]
        public string CoverPhoto { get; set; }
        public int? PostType { get; set; }
        [StringLength(5)]
        public string Language { get; set; }
        public long? PostId { get; set; }
        public Guid? Guid { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        public bool? IsOpenToComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublishedDate { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsStatu { get; set; }
        [StringLength(300)]
        public string Url { get; set; }
        public long? ViewCount { get; set; }
        public long? LikeCount { get; set; }
        public long? ShareToolClickCount { get; set; }
        public bool? IsNews { get; set; }
        public bool? IsPopular { get; set; }
        public bool? IsTrend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastScanDate { get; set; }
        public int? CommentCount { get; set; }
        [StringLength(50)]
        public string PostTags { get; set; }
        [StringLength(50)]
        public string PostCategory { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Surname { get; set; }
        [StringLength(200)]
        public string AccountIcon { get; set; }
        [StringLength(200)]
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
        public Guid? AccountsGuid { get; set; }
        public long AccountId { get; set; }
        public bool? AccountIsDeleted { get; set; }
        [StringLength(5)]
        public string AccountsLanguage { get; set; }
        public bool? PostIsDeleted { get; set; }
    }
}