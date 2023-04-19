using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Agency
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AgencyIATA.
        /// </summary>
        
        #nullable enable
        public string? AgencyIATA { set; get; }
        #nullable disable

/// <summary>
        /// AgencyCode.
        /// </summary>
        
        #nullable enable
        public string? AgencyCode { set; get; }
        #nullable disable

/// <summary>
        /// AgencyName.
        /// </summary>
        
        #nullable enable
        public string? AgencyName { set; get; }
        #nullable disable

/// <summary>
        /// AgencyRepresentative.
        /// </summary>
        
        #nullable enable
        public string? AgencyRepresentative { set; get; }
        #nullable disable

/// <summary>
        /// AgGrId.
        /// </summary>
        
        #nullable enable
        public string? AgGrId { set; get; }
        #nullable disable

/// <summary>
        /// CountryId.
        /// </summary>
        
        #nullable enable
        public string? CountryId { set; get; }
        #nullable disable

/// <summary>
        /// LanguagesId.
        /// </summary>
        
        #nullable enable
        public string? LanguagesId { set; get; }
        #nullable disable

/// <summary>
        /// AgencyTimestamp.
        /// </summary>
        
        #nullable enable
        public string? AgencyTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// AgencyActive.
        /// </summary>
        
        #nullable enable
        public bool? AgencyActive { set; get; }
        #nullable disable


    }
}




