﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class NotificationTemplates
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string ReplacedTags { get; set; }
        [StringLength(200)]
        public string Template { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int? LanguageId { get; set; }
    }
}