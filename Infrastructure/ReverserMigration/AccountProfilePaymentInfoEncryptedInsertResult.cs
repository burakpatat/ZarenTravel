﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfilePaymentInfoEncryptedInsertResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string BankName { get; set; }
        public int? TransferType { get; set; }
        public int? Country { get; set; }
        public string AccountInfo { get; set; }
        public string WalletAddress { get; set; }
        public decimal? Commission { get; set; }
    }
}
