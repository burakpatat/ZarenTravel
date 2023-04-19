using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Air
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AirlineId.
        /// </summary>
        
        #nullable enable
        public string? AirlineId { set; get; }
        #nullable disable

/// <summary>
        /// AirRecordAirline.
        /// </summary>
        
        #nullable enable
        public string? AirRecordAirline { set; get; }
        #nullable disable

/// <summary>
        /// AirTicket.
        /// </summary>
        
        #nullable enable
        public string? AirTicket { set; get; }
        #nullable disable

/// <summary>
        /// AirBookedDate.
        /// </summary>
        
        #nullable enable
        public DateTime? AirBookedDate { set; get; }
        #nullable disable

/// <summary>
        /// AirIssueddate.
        /// </summary>
        
        #nullable enable
        public DateTime? AirIssueddate { set; get; }
        #nullable disable

/// <summary>
        /// AirReIssued.
        /// </summary>
        
        #nullable enable
        public bool? AirReIssued { set; get; }
        #nullable disable

/// <summary>
        /// AirOriginalTicket.
        /// </summary>
        
        #nullable enable
        public string? AirOriginalTicket { set; get; }
        #nullable disable

/// <summary>
        /// PNRId.
        /// </summary>
        
        #nullable enable
        public string? PNRId { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyId.
        /// </summary>
        
        #nullable enable
        public string? CurrencyId { set; get; }
        #nullable disable

/// <summary>
        /// AirFare.
        /// </summary>
        
        #nullable enable
        public decimal? AirFare { set; get; }
        #nullable disable

/// <summary>
        /// AirTax.
        /// </summary>
        
        #nullable enable
        public decimal? AirTax { set; get; }
        #nullable disable

/// <summary>
        /// AirLowestFare.
        /// </summary>
        
        #nullable enable
        public decimal? AirLowestFare { set; get; }
        #nullable disable

/// <summary>
        /// AirHighestFare.
        /// </summary>
        
        #nullable enable
        public decimal? AirHighestFare { set; get; }
        #nullable disable

/// <summary>
        /// AirFareBases.
        /// </summary>
        
        #nullable enable
        public string? AirFareBases { set; get; }
        #nullable disable

/// <summary>
        /// BrokerId.
        /// </summary>
        
        #nullable enable
        public string? BrokerId { set; get; }
        #nullable disable

/// <summary>
        /// AirIncludeBags.
        /// </summary>
        
        #nullable enable
        public bool? AirIncludeBags { set; get; }
        #nullable disable

/// <summary>
        /// AirTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AirTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AirActive.
        /// </summary>
        
        #nullable enable
        public bool? AirActive { set; get; }
        #nullable disable


    }
}




