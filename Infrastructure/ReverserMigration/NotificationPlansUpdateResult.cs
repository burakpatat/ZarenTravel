﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class NotificationPlansUpdateResult
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public long? TriggerAuthorId { get; set; }
        public int? AuthorActionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string PreferredNotifyTypes { get; set; }
    }
}
