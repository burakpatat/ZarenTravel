﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountWalletEventsGetByIDResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public DateTime? EventDate { get; set; }
        public decimal? EarningPrice { get; set; }
        public long? PostId { get; set; }
        public int? CurrencyType { get; set; }
        public string Url { get; set; }
    }
}
