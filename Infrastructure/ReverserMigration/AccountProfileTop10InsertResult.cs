﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfileTop10InsertResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long PostId { get; set; }
        public long ProfileId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsSavedAllready { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
