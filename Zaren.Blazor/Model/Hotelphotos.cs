using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelPhotos")]
    public class Hotelphotos
    {
        public int Id{get;set;}
public int? HotelId{get;set;}
public int? HotelRoomId{get;set;}
public string Path{get;set;}
public int? Order{get;set;}
    }
}

