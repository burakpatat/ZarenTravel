﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class TagRelations
    {
        [Key]
        public int Id { get; set; }
        public int? TagId { get; set; }
        public int? ReleatedTagId { get; set; }
        public int? RelationHeavy { get; set; }
    }
}