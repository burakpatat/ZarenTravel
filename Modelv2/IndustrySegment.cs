using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class IndustrySegment
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// InSeDescription.
        /// </summary>
        
        #nullable enable
        public string? InSeDescription { set; get; }
        #nullable disable

/// <summary>
        /// InSeTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? InSeTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// InSeActive.
        /// </summary>
        
        #nullable enable
        public bool? InSeActive { set; get; }
        #nullable disable


    }
}




