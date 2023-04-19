using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class PassengerInformation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PnrpaxId.
        /// </summary>
        
        #nullable enable
        public string? PnrpaxId { set; get; }
        #nullable disable

/// <summary>
        /// Pnr.
        /// </summary>
        
        
        public string Pnr { set; get; }
        

/// <summary>
        /// PaxSequence.
        /// </summary>
        
        #nullable enable
        public string? PaxSequence { set; get; }
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
        /// AdultId.
        /// </summary>
        
        #nullable enable
        public string? AdultId { set; get; }
        #nullable disable

/// <summary>
        /// NationalityCode.
        /// </summary>
        
        #nullable enable
        public string? NationalityCode { set; get; }
        #nullable disable

/// <summary>
        /// TotalFare.
        /// </summary>
        
        #nullable enable
        public decimal? TotalFare { set; get; }
        #nullable disable

/// <summary>
        /// TotalTaxchg.
        /// </summary>
        
        #nullable enable
        public decimal? TotalTaxchg { set; get; }
        #nullable disable

/// <summary>
        /// TotalPaid.
        /// </summary>
        
        #nullable enable
        public decimal? TotalPaid { set; get; }
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




