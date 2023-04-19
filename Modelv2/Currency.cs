using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Currency
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CurrencyCode.
        /// </summary>
        
        #nullable enable
        public string? CurrencyCode { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyCodeIata.
        /// </summary>
        
        #nullable enable
        public string? CurrencyCodeIata { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyName.
        /// </summary>
        
        #nullable enable
        public string? CurrencyName { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CurrencyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyActive.
        /// </summary>
        
        #nullable enable
        public bool? CurrencyActive { set; get; }
        #nullable disable


    }
}




