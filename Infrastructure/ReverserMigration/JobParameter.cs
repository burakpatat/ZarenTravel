﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    [Table("JobParameter", Schema = "HangFire")]
    public partial class JobParameter
    {
        [Key]
        public long JobId { get; set; }
        [Key]
        [StringLength(40)]
        public string Name { get; set; }
        public string Value { get; set; }

        [ForeignKey("JobId")]
        [InverseProperty("JobParameter")]
        public virtual Job Job { get; set; }
    }
}