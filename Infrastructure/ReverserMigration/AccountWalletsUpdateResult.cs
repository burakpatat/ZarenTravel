﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountWalletsUpdateResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public decimal CurrentTotal { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        public int? CurrencyType { get; set; }
    }
}
