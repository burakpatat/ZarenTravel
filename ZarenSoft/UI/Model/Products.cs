using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("products")]
    public class Products
    {
        public int product_id{get;set;}
[Required]
public string product_name{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int brand_id{get;set;}
[Range(int.MinValue, int.MaxValue)]
public int category_id{get;set;}
[Range(int.MinValue, int.MaxValue)]
public Int16 model_year{get;set;}
[Required]
public decimal list_price{get;set;}
    }
}

