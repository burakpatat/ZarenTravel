using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("BookingDeals")]
    public class Bookingdeals
    {
        public int Id{get;set;}
public int? BookingId{get;set;}
public int? DealId{get;set;}
    }
}

