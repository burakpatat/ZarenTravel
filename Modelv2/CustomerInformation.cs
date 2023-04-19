using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class CustomerInformation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// CustomerId.
        /// </summary>
        
        
        public string CustomerId { set; get; }
        

/// <summary>
        /// EmailId.
        /// </summary>
        
        #nullable enable
        public string? EmailId { set; get; }
        #nullable disable

/// <summary>
        /// Title.
        /// </summary>
        
        #nullable enable
        public string? Title { set; get; }
        #nullable disable

/// <summary>
        /// FirstName.
        /// </summary>
        
        #nullable enable
        public string? FirstName { set; get; }
        #nullable disable

/// <summary>
        /// LastName.
        /// </summary>
        
        #nullable enable
        public string? LastName { set; get; }
        #nullable disable

/// <summary>
        /// Gender.
        /// </summary>
        
        #nullable enable
        public string? Gender { set; get; }
        #nullable disable

/// <summary>
        /// AlternativeEmailId.
        /// </summary>
        
        #nullable enable
        public string? AlternativeEmailId { set; get; }
        #nullable disable

/// <summary>
        /// Telephone.
        /// </summary>
        
        #nullable enable
        public string? Telephone { set; get; }
        #nullable disable

/// <summary>
        /// Mobile.
        /// </summary>
        
        #nullable enable
        public string? Mobile { set; get; }
        #nullable disable

/// <summary>
        /// CountryCode.
        /// </summary>
        
        #nullable enable
        public string? CountryCode { set; get; }
        #nullable disable

/// <summary>
        /// LanguageCode.
        /// </summary>
        
        #nullable enable
        public string? LanguageCode { set; get; }
        #nullable disable

/// <summary>
        /// OfficeTelephone.
        /// </summary>
        
        #nullable enable
        public string? OfficeTelephone { set; get; }
        #nullable disable

/// <summary>
        /// DateOfBirth.
        /// </summary>
        
        #nullable enable
        public DateTime? DateOfBirth { set; get; }
        #nullable disable

/// <summary>
        /// Fax.
        /// </summary>
        
        #nullable enable
        public string? Fax { set; get; }
        #nullable disable

/// <summary>
        /// NationalityCode.
        /// </summary>
        
        #nullable enable
        public string? NationalityCode { set; get; }
        #nullable disable

/// <summary>
        /// AgentCode.
        /// </summary>
        
        #nullable enable
        public string? AgentCode { set; get; }
        #nullable disable

/// <summary>
        /// CustomerId_N.
        /// </summary>
        
        #nullable enable
        public string? CustomerId_N { set; get; }
        #nullable disable

/// <summary>
        /// Totalpaxcount.
        /// </summary>
        
        #nullable enable
        public decimal? Totalpaxcount { set; get; }
        #nullable disable

/// <summary>
        /// TotalInfantcount.
        /// </summary>
        
        #nullable enable
        public decimal? TotalInfantcount { set; get; }
        #nullable disable

/// <summary>
        /// TotalFare.
        /// </summary>
        
        #nullable enable
        public decimal? TotalFare { set; get; }
        #nullable disable

/// <summary>
        /// TotalTaxChg.
        /// </summary>
        
        #nullable enable
        public decimal? TotalTaxChg { set; get; }
        #nullable disable

/// <summary>
        /// BookingStatus.
        /// </summary>
        
        #nullable enable
        public string? BookingStatus { set; get; }
        #nullable disable

/// <summary>
        /// ModificationDate.
        /// </summary>
        
        #nullable enable
        public DateTime? ModificationDate { set; get; }
        #nullable disable

/// <summary>
        /// FILE_ID.
        /// </summary>
        
        #nullable enable
        public string? FILE_ID { set; get; }
        #nullable disable

/// <summary>
        /// FILE_NAME.
        /// </summary>
        
        #nullable enable
        public string? FILE_NAME { set; get; }
        #nullable disable

/// <summary>
        /// RecordDateStamp.
        /// </summary>
        
        #nullable enable
        public DateTime? RecordDateStamp { set; get; }
        #nullable disable


    }
}




