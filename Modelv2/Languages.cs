using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Languages
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// LanguagesName.
        /// </summary>
        
        #nullable enable
        public string? LanguagesName { set; get; }
        #nullable disable

/// <summary>
        /// LanguagesCode.
        /// </summary>
        
        #nullable enable
        public string? LanguagesCode { set; get; }
        #nullable disable

/// <summary>
        /// LanguagesTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? LanguagesTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// LanguagesActive.
        /// </summary>
        
        #nullable enable
        public bool? LanguagesActive { set; get; }
        #nullable disable


    }
}




