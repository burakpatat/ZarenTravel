﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfileStatisticsSyncResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long? ProfileViewCount { get; set; }
        public long? PostViewCount { get; set; }
        public long? FollowCount { get; set; }
        public long? FollowerCount { get; set; }
        public long? CommentCount { get; set; }
        public long? PostLikedCount { get; set; }
        public long? PostBlockedCount { get; set; }
        public long? ProfileBlockedCount { get; set; }
        public DateTime LastScanDate { get; set; }
        public int? PostCountThisWeek { get; set; }
        public int? FollowerCountThisWeek { get; set; }
        public long? ViewCountThisWeek { get; set; }
        public string EarningThisMounth { get; set; }
        public long? PostDisLikedCount { get; set; }
        public int? PostSavedCount { get; set; }
    }
}
