using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("stores")]
    public class Stores
    {
        public int store_id{get;set;}
[Required]
public string store_name{get;set;}
public string phone{get;set;}
public string email{get;set;}
public string street{get;set;}
public string city{get;set;}
public string state{get;set;}
public string zip_code{get;set;}
    }
}

