using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("stocks")]
    public class Stocks
    {
        public int store_id{get;set;}
public int product_id{get;set;}
public int? quantity{get;set;}
    }
}

