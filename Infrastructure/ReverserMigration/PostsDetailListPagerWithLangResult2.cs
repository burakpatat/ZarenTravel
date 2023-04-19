﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class PostsDetailListPagerWithLangResult2
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public bool? IsViewable { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CoverPhoto { get; set; }
        public int? PostType { get; set; }
        public string Language { get; set; }
        public long? PostId { get; set; }
        public Guid? Guid { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        public bool? IsOpenToComment { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsStatu { get; set; }
        public string Url { get; set; }
        public long? ViewCount { get; set; }
        public long? LikeCount { get; set; }
        public long? ShareToolClickCount { get; set; }
        public bool? IsNews { get; set; }
        public bool? IsPopular { get; set; }
        public bool? IsTrend { get; set; }
        public DateTime? LastScanDate { get; set; }
        public int? CommentCount { get; set; }
        public string PostTags { get; set; }
        public string PostCategory { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccountIcon { get; set; }
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
        public Guid? AccountsGuid { get; set; }
        public long AccountId { get; set; }
        public bool? AccountIsDeleted { get; set; }
        public string AccountsLanguage { get; set; }
        public bool? PostIsDeleted { get; set; }
        public int? TotalRows { get; set; }
    }
}
