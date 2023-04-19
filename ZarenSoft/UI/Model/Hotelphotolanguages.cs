using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelPhotoLanguages")]
    public class Hotelphotolanguages
    {
        public int Id{get;set;}
public int? HotelPhotoId{get;set;}
public int? LanguageId{get;set;}
public string Description{get;set;}
    }
}

