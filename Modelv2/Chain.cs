using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Chain
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// ChainCode.
        /// </summary>
        
        #nullable enable
        public string? ChainCode { set; get; }
        #nullable disable

/// <summary>
        /// ChainName.
        /// </summary>
        
        #nullable enable
        public string? ChainName { set; get; }
        #nullable disable

/// <summary>
        /// ChainTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? ChainTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// ChainActive.
        /// </summary>
        
        #nullable enable
        public bool? ChainActive { set; get; }
        #nullable disable


    }
}




