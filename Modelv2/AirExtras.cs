using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AirExtras
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
        /// ExTyId.
        /// </summary>
        
        #nullable enable
        public string? ExTyId { set; get; }
        #nullable disable

/// <summary>
        /// AiExDescription.
        /// </summary>
        
        #nullable enable
        public string? AiExDescription { set; get; }
        #nullable disable

/// <summary>
        /// AiExFare.
        /// </summary>
        
        #nullable enable
        public decimal? AiExFare { set; get; }
        #nullable disable

/// <summary>
        /// AiExTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AiExTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AiExActive.
        /// </summary>
        
        #nullable enable
        public bool? AiExActive { set; get; }
        #nullable disable


    }
}




