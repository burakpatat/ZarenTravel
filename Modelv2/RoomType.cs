using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class RoomType
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// RoTyCode.
        /// </summary>
        
        #nullable enable
        public string? RoTyCode { set; get; }
        #nullable disable

/// <summary>
        /// RoTyDescription.
        /// </summary>
        
        #nullable enable
        public string? RoTyDescription { set; get; }
        #nullable disable

/// <summary>
        /// RoTyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? RoTyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// RoTyActive.
        /// </summary>
        
        #nullable enable
        public bool? RoTyActive { set; get; }
        #nullable disable


    }
}




