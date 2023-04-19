using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CarType
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CaTyCode.
        /// </summary>
        
        #nullable enable
        public string? CaTyCode { set; get; }
        #nullable disable

/// <summary>
        /// CaTyDescription.
        /// </summary>
        
        #nullable enable
        public string? CaTyDescription { set; get; }
        #nullable disable

/// <summary>
        /// CaTyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CaTyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CaTyActive.
        /// </summary>
        
        #nullable enable
        public bool? CaTyActive { set; get; }
        #nullable disable


    }
}




