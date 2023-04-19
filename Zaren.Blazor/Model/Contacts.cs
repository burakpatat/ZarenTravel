using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Contacts")]
    public class Contacts
    {
        public int Id{get;set;}
public string Name{get;set;}
public string TelNumber{get;set;}
public string FaxNumber{get;set;}
public string Email{get;set;}
    }
}

