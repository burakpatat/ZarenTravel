using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class HotelCodes
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// HotelId.
        /// </summary>
        
        #nullable enable
        public string? HotelId { set; get; }
        #nullable disable

/// <summary>
        /// BrokerId.
        /// </summary>
        
        #nullable enable
        public string? BrokerId { set; get; }
        #nullable disable

/// <summary>
        /// HoCoCode.
        /// </summary>
        
        #nullable enable
        public string? HoCoCode { set; get; }
        #nullable disable

/// <summary>
        /// HoCoTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? HoCoTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// HoCoActive.
        /// </summary>
        
        #nullable enable
        public bool? HoCoActive { set; get; }
        #nullable disable


    }
}




