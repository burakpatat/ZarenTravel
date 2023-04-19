using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AgencyGroup
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AgGrName.
        /// </summary>
        
        #nullable enable
        public string? AgGrName { set; get; }
        #nullable disable

/// <summary>
        /// AgGrTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? AgGrTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AgGrActive.
        /// </summary>
        
        #nullable enable
        public bool? AgGrActive { set; get; }
        #nullable disable


    }
}




