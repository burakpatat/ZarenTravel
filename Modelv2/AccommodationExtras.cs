using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AccommodationExtras
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AccommodationId.
        /// </summary>
        
        #nullable enable
        public string? AccommodationId { set; get; }
        #nullable disable

/// <summary>
        /// ExTyId.
        /// </summary>
        
        #nullable enable
        public string? ExTyId { set; get; }
        #nullable disable

/// <summary>
        /// AcExDescription.
        /// </summary>
        
        #nullable enable
        public string? AcExDescription { set; get; }
        #nullable disable

/// <summary>
        /// AcExFare.
        /// </summary>
        
        #nullable enable
        public string? AcExFare { set; get; }
        #nullable disable

/// <summary>
        /// AcExTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AcExTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AcExActive.
        /// </summary>
        
        #nullable enable
        public bool? AcExActive { set; get; }
        #nullable disable


    }
}




