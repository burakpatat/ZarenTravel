using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("CancelationLanguages")]
    public class Cancelationlanguages
    {
        public int Id{get;set;}
public int? CancelationRulesId{get;set;}
public int? LanguageId{get;set;}
public string Name{get;set;}
public string Description{get;set;}
    }
}

