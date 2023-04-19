using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Company
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CompanyCode.
        /// </summary>
        
        #nullable enable
        public string? CompanyCode { set; get; }
        #nullable disable

/// <summary>
        /// AgencyId.
        /// </summary>
        
        #nullable enable
        public string? AgencyId { set; get; }
        #nullable disable

/// <summary>
        /// CountryId.
        /// </summary>
        
        #nullable enable
        public string? CountryId { set; get; }
        #nullable disable

/// <summary>
        /// CompanyRepresentative.
        /// </summary>
        
        #nullable enable
        public string? CompanyRepresentative { set; get; }
        #nullable disable

/// <summary>
        /// CoGrId.
        /// </summary>
        
        #nullable enable
        public string? CoGrId { set; get; }
        #nullable disable

/// <summary>
        /// CoDiId.
        /// </summary>
        
        #nullable enable
        public string? CoDiId { set; get; }
        #nullable disable

/// <summary>
        /// LanguagesId.
        /// </summary>
        
        #nullable enable
        public string? LanguagesId { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyId.
        /// </summary>
        
        #nullable enable
        public string? CurrencyId { set; get; }
        #nullable disable

/// <summary>
        /// InSeId.
        /// </summary>
        
        #nullable enable
        public string? InSeId { set; get; }
        #nullable disable

/// <summary>
        /// CompanyTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CompanyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CompanyActive.
        /// </summary>
        
        #nullable enable
        public bool? CompanyActive { set; get; }
        #nullable disable


    }
}




