﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class DynamicSpaceReportResult
    {
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
        public long? Total_Reserved_kb { get; set; }
        public long? Used_Space_kb { get; set; }
        public string TypeDesc { get; set; }
        public long? RowsCount { get; set; }
    }
}
