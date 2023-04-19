using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class City
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CityCode.
        /// </summary>
        
        #nullable enable
        public string? CityCode { set; get; }
        #nullable disable

/// <summary>
        /// CityName.
        /// </summary>
        
        #nullable enable
        public string? CityName { set; get; }
        #nullable disable

/// <summary>
        /// CountryId.
        /// </summary>
        
        #nullable enable
        public string? CountryId { set; get; }
        #nullable disable

/// <summary>
        /// CityTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CityTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CityActive.
        /// </summary>
        
        #nullable enable
        public bool? CityActive { set; get; }
        #nullable disable


    }
}




