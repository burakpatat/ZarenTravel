﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class AccountGoalsGetAllResult
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventRule { get; set; }
        public string Language { get; set; }
        public string EventNameJSON { get; set; }
        public int? CountryId { get; set; }
        public int? PricePoint { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TableOrder { get; set; }
        public string Image { get; set; }
    }
}
