using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Airline
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AirlineCode.
        /// </summary>
        
        #nullable enable
        public string? AirlineCode { set; get; }
        #nullable disable

/// <summary>
        /// AirlineName.
        /// </summary>
        
        #nullable enable
        public string? AirlineName { set; get; }
        #nullable disable

/// <summary>
        /// AirlinePlate.
        /// </summary>
        
        #nullable enable
        public string? AirlinePlate { set; get; }
        #nullable disable

/// <summary>
        /// AirlineTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AirlineTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AirlineActive.
        /// </summary>
        
        #nullable enable
        public bool? AirlineActive { set; get; }
        #nullable disable


    }
}




