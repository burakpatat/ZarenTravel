﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class ResourcesUpdateResult
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public int? Language { get; set; }
        public bool? IsRTL { get; set; }
        public string Translation { get; set; }
        public string Statu { get; set; }
    }
}
