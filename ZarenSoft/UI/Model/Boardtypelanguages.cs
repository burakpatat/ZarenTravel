using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("BoardTypeLanguages")]
    public class Boardtypelanguages
    {
        public int Id{get;set;}
public int? LanguageId{get;set;}
public int? BoardTypeId{get;set;}
public string Name{get;set;}
    }
}

