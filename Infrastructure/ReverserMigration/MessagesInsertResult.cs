﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class MessagesInsertResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long ToAccountId { get; set; }
        public string Message { get; set; }
        public bool? IsRead { get; set; }
        public string ContentSource { get; set; }
        public int ContentType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
