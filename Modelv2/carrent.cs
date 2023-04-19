using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class carrent
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PNRId.
        /// </summary>
        
        #nullable enable
        public string? PNRId { set; get; }
        #nullable disable

/// <summary>
        /// CaTyId.
        /// </summary>
        
        #nullable enable
        public string? CaTyId { set; get; }
        #nullable disable

/// <summary>
        /// CaRtId.
        /// </summary>
        
        #nullable enable
        public string? CaRtId { set; get; }
        #nullable disable

/// <summary>
        /// AirportIdPickUp.
        /// </summary>
        
        #nullable enable
        public string? AirportIdPickUp { set; get; }
        #nullable disable

/// <summary>
        /// AirportIdReturn.
        /// </summary>
        
        #nullable enable
        public string? AirportIdReturn { set; get; }
        #nullable disable

/// <summary>
        /// CaRePickUpDate.
        /// </summary>
        
        #nullable enable
        public DateTime? CaRePickUpDate { set; get; }
        #nullable disable

/// <summary>
        /// CaReReturnDate.
        /// </summary>
        
        #nullable enable
        public DateTime? CaReReturnDate { set; get; }
        #nullable disable

/// <summary>
        /// CaReRate.
        /// </summary>
        
        #nullable enable
        public decimal? CaReRate { set; get; }
        #nullable disable

/// <summary>
        /// CaReTax.
        /// </summary>
        
        #nullable enable
        public decimal? CaReTax { set; get; }
        #nullable disable

/// <summary>
        /// CurrencyId.
        /// </summary>
        
        #nullable enable
        public string? CurrencyId { set; get; }
        #nullable disable

/// <summary>
        /// CaReBookDate.
        /// </summary>
        
        #nullable enable
        public DateTime? CaReBookDate { set; get; }
        #nullable disable

/// <summary>
        /// CaReTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? CaReTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// CaReActive.
        /// </summary>
        
        #nullable enable
        public bool? CaReActive { set; get; }
        #nullable disable


    }
}




