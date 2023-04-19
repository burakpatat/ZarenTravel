﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountWalletRequests
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequestDate { get; set; }
        public int? TransferType { get; set; }
        public int? CountryId { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? RequestedAmount { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? CommissionRate { get; set; }
        public bool? SendNotification { get; set; }
        public bool? HasCompleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletedDate { get; set; }
        public int? RequestedAmountCurrency { get; set; }
        [StringLength(100)]
        public string GoogleClientId { get; set; }
        [Column("IPAddress")]
        [StringLength(50)]
        public string Ipaddress { get; set; }
        [StringLength(50)]
        public string SessionInfo { get; set; }
        public string AccountAgent { get; set; }
        public long AccountDeviceId { get; set; }
    }
}