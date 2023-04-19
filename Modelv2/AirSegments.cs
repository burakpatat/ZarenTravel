using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AirSegments
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AirId.
        /// </summary>
        
        #nullable enable
        public string? AirId { set; get; }
        #nullable disable

/// <summary>
        /// AirlineId.
        /// </summary>
        
        #nullable enable
        public string? AirlineId { set; get; }
        #nullable disable

/// <summary>
        /// AiSeDeparture.
        /// </summary>
        
        #nullable enable
        public DateTime? AiSeDeparture { set; get; }
        #nullable disable

/// <summary>
        /// AiSeArrival.
        /// </summary>
        
        #nullable enable
        public DateTime? AiSeArrival { set; get; }
        #nullable disable

/// <summary>
        /// AirportIdOrigin.
        /// </summary>
        
        #nullable enable
        public string? AirportIdOrigin { set; get; }
        #nullable disable

/// <summary>
        /// AirportIdDestination.
        /// </summary>
        
        #nullable enable
        public string? AirportIdDestination { set; get; }
        #nullable disable

/// <summary>
        /// AiSeFlightNumber.
        /// </summary>
        
        #nullable enable
        public string? AiSeFlightNumber { set; get; }
        #nullable disable

/// <summary>
        /// AiSeClass.
        /// </summary>
        
        #nullable enable
        public bool? AiSeClass { set; get; }
        #nullable disable

/// <summary>
        /// TerminalIdOrigin.
        /// </summary>
        
        #nullable enable
        public string? TerminalIdOrigin { set; get; }
        #nullable disable

/// <summary>
        /// TerminalIdDestination.
        /// </summary>
        
        #nullable enable
        public string? TerminalIdDestination { set; get; }
        #nullable disable

/// <summary>
        /// AiSeTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AiSeTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AiSeActive.
        /// </summary>
        
        #nullable enable
        public bool? AiSeActive { set; get; }
        #nullable disable


    }
}




