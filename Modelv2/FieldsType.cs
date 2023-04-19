using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class FieldsType
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// FiTyCode.
        /// </summary>
        
        #nullable enable
        public string? FiTyCode { set; get; }
        #nullable disable

/// <summary>
        /// FiTyName.
        /// </summary>
        
        #nullable enable
        public string? FiTyName { set; get; }
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




