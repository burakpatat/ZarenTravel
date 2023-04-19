using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Hotel
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// HotelName.
        /// </summary>
        
        #nullable enable
        public string? HotelName { set; get; }
        #nullable disable

/// <summary>
        /// CityId.
        /// </summary>
        
        #nullable enable
        public string? CityId { set; get; }
        #nullable disable

/// <summary>
        /// ChainId.
        /// </summary>
        
        #nullable enable
        public string? ChainId { set; get; }
        #nullable disable

/// <summary>
        /// HotelTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? HotelTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// HotelActive.
        /// </summary>
        
        #nullable enable
        public bool? HotelActive { set; get; }
        #nullable disable


    }
}




