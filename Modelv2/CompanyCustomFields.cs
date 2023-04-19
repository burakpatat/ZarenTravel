using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CompanyCustomFields
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CompanyId.
        /// </summary>
        
        #nullable enable
        public string? CompanyId { set; get; }
        #nullable disable

/// <summary>
        /// CoCuCode.
        /// </summary>
        
        #nullable enable
        public string? CoCuCode { set; get; }
        #nullable disable

/// <summary>
        /// FiTyId.
        /// </summary>
        
        #nullable enable
        public string? FiTyId { set; get; }
        #nullable disable

/// <summary>
        /// CoCuTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CoCuTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CoCuActive.
        /// </summary>
        
        #nullable enable
        public string? CoCuActive { set; get; }
        #nullable disable


    }
}




