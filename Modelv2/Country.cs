using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Country
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CountryCode.
        /// </summary>
        
        #nullable enable
        public string? CountryCode { set; get; }
        #nullable disable

/// <summary>
        /// CountryName.
        /// </summary>
        
        #nullable enable
        public string? CountryName { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyId.
        /// </summary>
        
        #nullable enable
        public string? CurrencyId { set; get; }
        #nullable disable

/// <summary>
        /// CountryTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CountryTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CountryActive.
        /// </summary>
        
        #nullable enable
        public bool? CountryActive { set; get; }
        #nullable disable


    }
}




