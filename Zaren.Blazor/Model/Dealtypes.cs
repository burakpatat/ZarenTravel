using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("DealTypes")]
    public class Dealtypes
    {
        public int Id{get;set;}
public int? Name{get;set;}
    }
}

