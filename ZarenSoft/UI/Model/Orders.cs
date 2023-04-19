using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("orders")]
    public class Orders
    {
        public int order_id{get;set;}
public int? customer_id{get;set;}
[Required]
public byte order_status{get;set;}
[Required]
public DateTime order_date{get;set;}
[Required]
public DateTime required_date{get;set;}
public DateTime? shipped_date{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int store_id{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int staff_id{get;set;}
public DateTime? created_on{get;set;}
    }
}

