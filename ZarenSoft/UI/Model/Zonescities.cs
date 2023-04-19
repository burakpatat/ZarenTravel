using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("ZonesCities")]
    public class Zonescities
    {
        public int Id{get;set;}
public int? CityId{get;set;}
public int? ZoneId{get;set;}
public string MainZone{get;set;}
    }
}

