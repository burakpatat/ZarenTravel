﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class ContentAccordionsInsertResult
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public bool? IsPublished { get; set; }
        public string Language { get; set; }
        public int? TableOrder { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
