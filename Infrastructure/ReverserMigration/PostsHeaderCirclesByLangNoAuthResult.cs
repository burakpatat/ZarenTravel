﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class PostsHeaderCirclesByLangNoAuthResult
    {
        public long? Id { get; set; }
        public Guid? Guid { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CoverPhoto { get; set; }
        public long? LikeCount { get; set; }
        public Guid? AccountGuid { get; set; }
        public string AccountIcon { get; set; }
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
    }
}
