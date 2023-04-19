using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class SegmentInformation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PNRSegId.
        /// </summary>
        
        #nullable enable
        public string? PNRSegId { set; get; }
        #nullable disable

/// <summary>
        /// PNR.
        /// </summary>
        
        #nullable enable
        public string? PNR { set; get; }
        #nullable disable

/// <summary>
        /// FlightNumber.
        /// </summary>
        
        #nullable enable
        public string? FlightNumber { set; get; }
        #nullable disable

/// <summary>
        /// Origin.
        /// </summary>
        
        #nullable enable
        public string? Origin { set; get; }
        #nullable disable

/// <summary>
        /// Destination.
        /// </summary>
        
        #nullable enable
        public string? Destination { set; get; }
        #nullable disable

/// <summary>
        /// Segmentcode.
        /// </summary>
        
        #nullable enable
        public string? Segmentcode { set; get; }
        #nullable disable

/// <summary>
        /// EsttimeDepartureLocal.
        /// </summary>
        
        #nullable enable
        public DateTime? EsttimeDepartureLocal { set; get; }
        #nullable disable

/// <summary>
        /// EsttimeArrivalLocal.
        /// </summary>
        
        #nullable enable
        public DateTime? EsttimeArrivalLocal { set; get; }
        #nullable disable

/// <summary>
        /// Daynumber.
        /// </summary>
        
        #nullable enable
        public string? Daynumber { set; get; }
        #nullable disable

/// <summary>
        /// SegmentStatus.
        /// </summary>
        
        #nullable enable
        public string? SegmentStatus { set; get; }
        #nullable disable

/// <summary>
        /// ModificationDate.
        /// </summary>
        
        #nullable enable
        public DateTime? ModificationDate { set; get; }
        #nullable disable

/// <summary>
        /// FILE_ID.
        /// </summary>
        
        #nullable enable
        public string? FILE_ID { set; get; }
        #nullable disable

/// <summary>
        /// FILE_NAME.
        /// </summary>
        
        #nullable enable
        public string? FILE_NAME { set; get; }
        #nullable disable

/// <summary>
        /// RecordDateStamp.
        /// </summary>
        
        #nullable enable
        public DateTime? RecordDateStamp { set; get; }
        #nullable disable


    }
}




