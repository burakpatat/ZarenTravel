using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("CancellationSeasons")]
    public class Cancellationseasons
    {
        public int Id{get;set;}
public int? HotelId{get;set;}
public DateTime? StartDate{get;set;}
public DateTime? EndDate{get;set;}
    }
}

