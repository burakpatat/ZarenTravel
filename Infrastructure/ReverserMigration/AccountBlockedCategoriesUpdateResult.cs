﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountBlockedCategoriesUpdateResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long CategoryId { get; set; }
        public bool? IsBlockedAllready { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
