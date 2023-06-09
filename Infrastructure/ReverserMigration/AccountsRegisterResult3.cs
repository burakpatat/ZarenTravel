﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountsRegisterResult3
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccountIcon { get; set; }
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
        public string Language { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? Guid { get; set; }
        public string PersonelInfo { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string CoverImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Currency { get; set; }
        public string GoogleId { get; set; }
        public string AppleId { get; set; }
        public int? CountryId { get; set; }
        public long? ProfileViewCount { get; set; }
        public long? PostViewCount { get; set; }
        public long? FollowCount { get; set; }
        public long? FollowerCount { get; set; }
        public long? CommentCount { get; set; }
        public long? PostLikedCount { get; set; }
        public long? PostBlockedCount { get; set; }
        public long? ProfileBlockedCount { get; set; }
        public DateTime? LastScanDate { get; set; }
        public int? PostCountThisWeek { get; set; }
        public int? FollowerCountThisWeek { get; set; }
        public long? ViewCountThisWeek { get; set; }
        public string EarningThisMounth { get; set; }
    }
}
