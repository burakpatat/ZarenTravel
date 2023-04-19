using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class ReservationInformation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PNR.
        /// </summary>
        
        #nullable enable
        public string? PNR { set; get; }
        #nullable disable

/// <summary>
        /// BookingTimeStamp.
        /// </summary>
        
        #nullable enable
        public DateTime? BookingTimeStamp { set; get; }
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
        /// PassportNumber.
        /// </summary>
        
        #nullable enable
        public string? PassportNumber { set; get; }
        #nullable disable

/// <summary>
        /// StreetAddress1.
        /// </summary>
        
        #nullable enable
        public string? StreetAddress1 { set; get; }
        #nullable disable

/// <summary>
        /// StreetAddress2.
        /// </summary>
        
        #nullable enable
        public string? StreetAddress2 { set; get; }
        #nullable disable

/// <summary>
        /// City.
        /// </summary>
        
        #nullable enable
        public string? City { set; get; }
        #nullable disable

/// <summary>
        /// State.
        /// </summary>
        
        #nullable enable
        public string? State { set; get; }
        #nullable disable

/// <summary>
        /// CountryCode.
        /// </summary>
        
        #nullable enable
        public string? CountryCode { set; get; }
        #nullable disable

/// <summary>
        /// PhoneNo.
        /// </summary>
        
        #nullable enable
        public string? PhoneNo { set; get; }
        #nullable disable

/// <summary>
        /// MobileNo.
        /// </summary>
        
        #nullable enable
        public string? MobileNo { set; get; }
        #nullable disable

/// <summary>
        /// Fax.
        /// </summary>
        
        #nullable enable
        public string? Fax { set; get; }
        #nullable disable

/// <summary>
        /// Email.
        /// </summary>
        
        #nullable enable
        public string? Email { set; get; }
        #nullable disable

/// <summary>
        /// NationalityCode.
        /// </summary>
        
        #nullable enable
        public string? NationalityCode { set; get; }
        #nullable disable

/// <summary>
        /// SalesChannelCode.
        /// </summary>
        
        #nullable enable
        public string? SalesChannelCode { set; get; }
        #nullable disable

/// <summary>
        /// AgentCode.
        /// </summary>
        
        #nullable enable
        public string? AgentCode { set; get; }
        #nullable disable

/// <summary>
        /// CustomerId.
        /// </summary>
        
        #nullable enable
        public string? CustomerId { set; get; }
        #nullable disable

/// <summary>
        /// Totalpaxcount.
        /// </summary>
        
        #nullable enable
        public string? Totalpaxcount { set; get; }
        #nullable disable

/// <summary>
        /// TotalInfantcount.
        /// </summary>
        
        #nullable enable
        public string? TotalInfantcount { set; get; }
        #nullable disable

/// <summary>
        /// TotalTaxChg.
        /// </summary>
        
        #nullable enable
        public decimal? TotalTaxChg { set; get; }
        #nullable disable

/// <summary>
        /// TotalFare.
        /// </summary>
        
        #nullable enable
        public decimal? TotalFare { set; get; }
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




