using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class PNRCustomFields
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// FiTyId.
        /// </summary>
        
        #nullable enable
        public string? FiTyId { set; get; }
        #nullable disable

/// <summary>
        /// PNRId.
        /// </summary>
        
        #nullable enable
        public string? PNRId { set; get; }
        #nullable disable

/// <summary>
        /// PnCuValue.
        /// </summary>
        
        #nullable enable
        public string? PnCuValue { set; get; }
        #nullable disable

/// <summary>
        /// FiTyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? FiTyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// FiTyActive.
        /// </summary>
        
        #nullable enable
        public bool? FiTyActive { set; get; }
        #nullable disable


    }
}




