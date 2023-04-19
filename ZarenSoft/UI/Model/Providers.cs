using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("Providers")]
    public class Providers
    {
        public int Id{get;set;}
public string Name{get;set;}
public string Address{get;set;}
public string Website{get;set;}
public int? ComercialContactId{get;set;}
public int? ReservationContactId{get;set;}
public int? FinanceContactId{get;set;}
    }
}

