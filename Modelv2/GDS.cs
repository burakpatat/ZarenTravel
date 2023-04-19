using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class GDS
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// GDSName.
        /// </summary>
        
        #nullable enable
        public string? GDSName { set; get; }
        #nullable disable

/// <summary>
        /// GDSTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? GDSTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// GDSActive.
        /// </summary>
        
        #nullable enable
        public bool? GDSActive { set; get; }
        #nullable disable


    }
}




