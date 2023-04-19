using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CompanyGroup
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CoGrName.
        /// </summary>
        
        #nullable enable
        public string? CoGrName { set; get; }
        #nullable disable

/// <summary>
        /// CoGrTravelManager.
        /// </summary>
        
        #nullable enable
        public string? CoGrTravelManager { set; get; }
        #nullable disable

/// <summary>
        /// CoGrTimestamp.
        /// </summary>
        
        #nullable enable
        public string? CoGrTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CoGrActive.
        /// </summary>
        
        #nullable enable
        public bool? CoGrActive { set; get; }
        #nullable disable


    }
}




