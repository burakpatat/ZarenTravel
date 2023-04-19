using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Regions")]
    public class Regions
    {
        public int Id{get;set;}
public int? CountryId{get;set;}
public string Name{get;set;}
public string LatLongBounds{get;set;}
    }
}

