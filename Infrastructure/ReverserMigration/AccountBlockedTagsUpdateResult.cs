﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountBlockedTagsUpdateResult
    {
        public long Id { get; set; }
        public long? TagId { get; set; }
        public long AccountId { get; set; }
        public bool? IsBlockedAllReady { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
