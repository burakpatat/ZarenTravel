﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountsLoginWithAppleIdResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccountIcon { get; set; }
        public string AccountName { get; set; }
        public bool? IsVerified { get; set; }
        public string Language { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? Guid { get; set; }
    }
}
