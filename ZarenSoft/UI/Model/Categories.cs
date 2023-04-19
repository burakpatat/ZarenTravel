using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("categories")]
    public class Categories
    {
        public int category_id{get;set;}
[Required]
public string category_name{get;set;}
    }
}

