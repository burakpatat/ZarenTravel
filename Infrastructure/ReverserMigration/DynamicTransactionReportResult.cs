﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class DynamicTransactionReportResult
    {
        public DateTime CurrentTime { get; set; }
        public string LoginName { get; set; }
        public string DatabaseName { get; set; }
        [Column("Transactio BeginTime")]
        public DateTime? TransactioBeginTime { get; set; }
        public long LogUsedBytes { get; set; }
        public long LogReservedBytes { get; set; }
        public string QueryText { get; set; }
    }
}