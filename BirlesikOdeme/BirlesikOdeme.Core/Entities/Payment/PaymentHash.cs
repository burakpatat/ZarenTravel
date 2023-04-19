using BirlesikOdeme.Core.Entities.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    /// <summary>
    /// dokümanlara ve maildeki verileri direkt yazdım.
    /// </summary>
    public class PaymentHash  
    {
        public string HashPassword { get; set; }  
        public string OkUrl { get; set; }  
        public string FailUrl { get; set; } 
        public string UserCode { get; set; }  
        public string Rnd { get; set; }  
        public long MemberId { get; set; }  
        public long MerchantId { get; set; }  
        public string txnType { get; set; }  
        public string TotalAmount { get; set; }  
        public string CustomerId { get; set; } 
        public string OrderId { get; set; }  

    }
 
