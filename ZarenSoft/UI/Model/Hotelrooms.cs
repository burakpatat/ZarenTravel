using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelRooms")]
    public class Hotelrooms
    {
        public int Id{get;set;}
public int? HotelBuyRoomId{get;set;}
public int? RoomId{get;set;}
public string Name{get;set;}
public int? Adults{get;set;}
public int? Children{get;set;}
public int? Infants{get;set;}
    }
}

