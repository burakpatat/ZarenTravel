﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountProfileInfoGetAllResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string PersonelInfo { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string CoverImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? HasSentNotifyOnComment { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
    }
}
