using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Cities")]
    public class Cities
    {
        public int Id{get;set;}
public string Name{get;set;}
public decimal? Latitude{get;set;}
public decimal? Longitude{get;set;}
    }
}

