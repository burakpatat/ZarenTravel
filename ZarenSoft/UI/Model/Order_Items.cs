using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("order_items")]
    public class Order_Items
    {
        public int order_id{get;set;}
public int item_id{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int product_id{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int quantity{get;set;}
[Required]
public decimal list_price{get;set;}
public decimal? discount{get;set;}
    }
}

