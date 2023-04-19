using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CarRental
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CaRtCode.
        /// </summary>
        
        #nullable enable
        public string? CaRtCode { set; get; }
        #nullable disable

/// <summary>
        /// CaRtName.
        /// </summary>
        
        #nullable enable
        public string? CaRtName { set; get; }
        #nullable disable

/// <summary>
        /// CaRtTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CaRtTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CaRtActive.
        /// </summary>
        
        #nullable enable
        public bool? CaRtActive { set; get; }
        #nullable disable


    }
}




