﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class GetTableSizeResult
    {
        public string name { get; set; }
        public string TableName { get; set; }
        public long? RowCounts { get; set; }
        public long? TotalSpaceKB { get; set; }
        public string TotalSpaceKB_Swiss { get; set; }
        public long? UsedSpaceKB { get; set; }
        public long? UnusedSpaceKB { get; set; }
    }
}
