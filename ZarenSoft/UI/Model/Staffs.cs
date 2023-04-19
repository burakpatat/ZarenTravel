using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("staffs")]
    public class Staffs
    {
        public int staff_id{get;set;}
[Required]
public string first_name{get;set;}
[Required]
public string last_name{get;set;}
[Required]
public string email{get;set;}
public string phone{get;set;}
[Required]
public byte active{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int store_id{get;set;}
public int? manager_id{get;set;}
    }
}

