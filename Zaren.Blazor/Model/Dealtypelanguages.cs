using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("DealTypeLanguages")]
    public class Dealtypelanguages
    {
        public int Id{get;set;}
public int? DealTypeId{get;set;}
public int? LanguageId{get;set;}
public string Name{get;set;}
public string Description{get;set;}
    }
}

