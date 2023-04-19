using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelDescriptions")]
    public class Hoteldescriptions
    {
        public int Id{get;set;}
public int? HotelId{get;set;}
public int? LanguageId{get;set;}
public string Description{get;set;}
    }
}

