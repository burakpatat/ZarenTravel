using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Airport
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AirportCode.
        /// </summary>
        
        #nullable enable
        public string? AirportCode { set; get; }
        #nullable disable

/// <summary>
        /// AirportName.
        /// </summary>
        
        #nullable enable
        public string? AirportName { set; get; }
        #nullable disable

/// <summary>
        /// CountryId.
        /// </summary>
        
        #nullable enable
        public string? CountryId { set; get; }
        #nullable disable

/// <summary>
        /// CityId.
        /// </summary>
        
        #nullable enable
        public string? CityId { set; get; }
        #nullable disable

/// <summary>
        /// AirportTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AirportTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AirportActive.
        /// </summary>
        
        #nullable enable
        public bool? AirportActive { set; get; }
        #nullable disable


    }
}




