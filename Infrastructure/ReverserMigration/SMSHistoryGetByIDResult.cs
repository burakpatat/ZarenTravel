﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class SMSHistoryGetByIDResult
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public string SMSCodes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsSuccessfull { get; set; }
        public int? AttempCount { get; set; }
        public int? MaxAttempCount { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }
}
