﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfilePinnedUpdateResult
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long AccountId { get; set; }
        public int? TableOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsPinnedAllready { get; set; }
    }
}
