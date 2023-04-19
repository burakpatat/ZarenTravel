using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Rooms")]
    public class Rooms
    {
        public int Id{get;set;}
public string Name{get;set;}
public string Description{get;set;}
public int? Adults{get;set;}
public int? Children{get;set;}
public int? Infants{get;set;}
    }
}

