﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class GetServerInfoResult
    {
        public string name { get; set; }
        public byte compatibility_level { get; set; }
        public byte[] owner_sid { get; set; }
        public string collation_name { get; set; }
        public byte? snapshot_isolation_state { get; set; }
        public bool? is_fulltext_enabled { get; set; }
        public string state_desc { get; set; }
        public string user_access_desc { get; set; }
        public bool? is_read_only { get; set; }
        public bool? IsSystemDatabase { get; set; }
    }
}