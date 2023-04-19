using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Deals")]
    public class Deals
    {
        public int Id{get;set;}
public int? HotelRoomId{get;set;}
public int? BoardTypeId{get;set;}
public int? DealTypeId{get;set;}
public int? Release{get;set;}
public decimal? Discount{get;set;}
public int? FreeNights{get;set;}
public DateTime? StartDate{get;set;}
public DateTime? EndDate{get;set;}
    }
}
