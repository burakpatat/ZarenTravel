using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class ExtrasType
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// ExTyCode.
        /// </summary>
        
        #nullable enable
        public string? ExTyCode { set; get; }
        #nullable disable

/// <summary>
        /// ExTyName.
        /// </summary>
        
        #nullable enable
        public string? ExTyName { set; get; }
        #nullable disable

/// <summary>
        /// ExTyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? ExTyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// ExTyActive.
        /// </summary>
        
        #nullable enable
        public bool? ExTyActive { set; get; }
        #nullable disable


    }
}




