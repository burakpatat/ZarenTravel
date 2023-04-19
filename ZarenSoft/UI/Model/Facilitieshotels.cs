using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("FacilitiesHotels")]
    public class Facilitieshotels
    {
        public int Id{get;set;}
public int? HotelId{get;set;}
public int? HotelRoomId{get;set;}
public int? FacilityId{get;set;}
    }
}

