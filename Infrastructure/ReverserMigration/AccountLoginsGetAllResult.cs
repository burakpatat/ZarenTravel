﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountLoginsGetAllResult
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string AccountAgent { get; set; }
        public string Token { get; set; }
        public bool? IsSuccessfull { get; set; }
        public string IPAddress { get; set; }
        public DateTime? ExpiresIn { get; set; }
        public string Language { get; set; }
        public long AccountDeviceId { get; set; }
    }
}