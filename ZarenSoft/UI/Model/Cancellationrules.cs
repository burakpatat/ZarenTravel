using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("CancellationRules")]
    public class Cancellationrules
    {
        public int Id{get;set;}
public int? CancellationSeasonId{get;set;}
public decimal? Cost{get;set;}
public int? CostType{get;set;}
public int? FromDays{get;set;}
public int? ToDays{get;set;}
    }
}

