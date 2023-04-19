using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CompanyDivisions
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CoDiName.
        /// </summary>
        
        #nullable enable
        public string? CoDiName { set; get; }
        #nullable disable

/// <summary>
        /// CoDiCode.
        /// </summary>
        
        #nullable enable
        public string? CoDiCode { set; get; }
        #nullable disable

/// <summary>
        /// CoDiTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CoDiTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CoDiActive.
        /// </summary>
        
        #nullable enable
        public bool? CoDiActive { set; get; }
        #nullable disable


    }
}




