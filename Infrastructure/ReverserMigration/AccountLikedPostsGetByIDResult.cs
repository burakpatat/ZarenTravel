﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountLikedPostsGetByIDResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long PostId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long AuthorId { get; set; }
        public bool? IsLikedAllready { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
