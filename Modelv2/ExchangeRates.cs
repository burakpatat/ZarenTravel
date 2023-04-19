using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class ExchangeRates
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CurrencyIdFrom.
        /// </summary>
        
        #nullable enable
        public string? CurrencyIdFrom { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyIdTo.
        /// </summary>
        
        #nullable enable
        public string? CurrencyIdTo { set; get; }
        #nullable disable

/// <summary>
        /// ExRaValue.
        /// </summary>
        
        #nullable enable
        public decimal? ExRaValue { set; get; }
        #nullable disable

/// <summary>
        /// ExRaDate.
        /// </summary>
        
        #nullable enable
        public DateTime? ExRaDate { set; get; }
        #nullable disable

/// <summary>
        /// ExRaTimestamp.
        /// </summary>
        
        #nullable enable
        public string? ExRaTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// ExRaActive.
        /// </summary>
        
        #nullable enable
        public bool? ExRaActive { set; get; }
        #nullable disable


    }
}




