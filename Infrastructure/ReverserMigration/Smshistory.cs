﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    [Table("SMSHistory")]
    public partial class Smshistory
    {
        [Key]
        public long Id { get; set; }
        public long? AccountId { get; set; }
        [Column("SMSCodes")]
        [StringLength(20)]
        public string Smscodes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsSuccessfull { get; set; }
        public int? AttempCount { get; set; }
        public int? MaxAttempCount { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(10)]
        public string CountryCode { get; set; }
    }
}