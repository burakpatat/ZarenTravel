﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountNewsletterInfoGetAllResult
    {
        public int Id { get; set; }
        public long AccountId { get; set; }
        public int? MailFrequency { get; set; }
        public int? NotifyType { get; set; }
        public string NewsletterMail { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
