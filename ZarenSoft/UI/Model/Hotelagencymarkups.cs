using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelAgencyMarkups")]
    public class Hotelagencymarkups
    {
        public int Id{get;set;}
public int? AgencyId{get;set;}
public int? HotelId{get;set;}
public decimal? MarkUp{get;set;}
public DateTime? StartDate{get;set;}
public DateTime? EndDate{get;set;}
    }
}

