﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class NotificationTemplatesGetByIDResult
    {
        public int Id { get; set; }
        public string ReplacedTags { get; set; }
        public string Template { get; set; }
        public string Name { get; set; }
        public int? LanguageId { get; set; }
    }
}
