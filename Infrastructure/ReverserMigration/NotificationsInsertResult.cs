﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class NotificationsInsertResult
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public bool? IsRead { get; set; }
        public string Message { get; set; }
        public int? NotifyType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? ToAll { get; set; }
    }
}
