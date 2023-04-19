using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Accommodation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PNRId.
        /// </summary>
        
        #nullable enable
        public string? PNRId { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationCheckIN.
        /// </summary>
        
        #nullable enable
        public DateTime? AccommodationCheckIN { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationCheckOUT.
        /// </summary>
        
        #nullable enable
        public DateTime? AccommodationCheckOUT { set; get; }
        #nullable disable

/// <summary>
        /// HotelId.
        /// </summary>
        
        #nullable enable
        public string? HotelId { set; get; }
        #nullable disable

/// <summary>
        /// RoTyId.
        /// </summary>
        
        #nullable enable
        public string? RoTyId { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationRate.
        /// </summary>
        
        #nullable enable
        public decimal? AccommodationRate { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyId.
        /// </summary>
        
        #nullable enable
        public string? CurrencyId { set; get; }
        #nullable disable

/// <summary>
        /// BrokerId.
        /// </summary>
        
        #nullable enable
        public string? BrokerId { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationBookedDate.
        /// </summary>
        
        #nullable enable
        public DateTime? AccommodationBookedDate { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationTimestap.
        /// </summary>
        
        #nullable enable
        public DateTime? AccommodationTimestap { set; get; }
        #nullable disable

/// <summary>
        /// AccommodationActive.
        /// </summary>
        
        #nullable enable
        public bool? AccommodationActive { set; get; }
        #nullable disable


    }
}




