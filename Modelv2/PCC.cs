using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class PCC
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PCCCode.
        /// </summary>
        
        #nullable enable
        public string? PCCCode { set; get; }
        #nullable disable

/// <summary>
        /// PCCIata.
        /// </summary>
        
        #nullable enable
        public string? PCCIata { set; get; }
        #nullable disable

/// <summary>
        /// AgencyId.
        /// </summary>
        
        #nullable enable
        public string? AgencyId { set; get; }
        #nullable disable

/// <summary>
        /// GDSId.
        /// </summary>
        
        #nullable enable
        public string? GDSId { set; get; }
        #nullable disable

/// <summary>
        /// PCCTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? PCCTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// PCCActive.
        /// </summary>
        
        #nullable enable
        public bool? PCCActive { set; get; }
        #nullable disable


    }
}




