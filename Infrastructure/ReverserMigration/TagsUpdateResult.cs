﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class TagsUpdateResult
    {
        public long Id { get; set; }
        public long CreatedByAdminAccount { get; set; }
        public long CreatedByAccount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public long? ParentTagId { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
