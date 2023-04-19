using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("FacilityLanguages")]
    public class Facilitylanguages
    {
        public int Id{get;set;}
public int? FacilityId{get;set;}
public int? LanguageId{get;set;}
public string Name{get;set;}
    }
}

