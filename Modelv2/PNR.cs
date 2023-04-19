using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class PNR
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AgencyId.
        /// </summary>
        
        #nullable enable
        public string? AgencyId { set; get; }
        #nullable disable

/// <summary>
        /// PCCId.
        /// </summary>
        
        #nullable enable
        public string? PCCId { set; get; }
        #nullable disable

/// <summary>
        /// CompanyId.
        /// </summary>
        
        #nullable enable
        public string? CompanyId { set; get; }
        #nullable disable

/// <summary>
        /// PassengerId.
        /// </summary>
        
        #nullable enable
        public string? PassengerId { set; get; }
        #nullable disable

/// <summary>
        /// PNRRecord.
        /// </summary>
        
        #nullable enable
        public string? PNRRecord { set; get; }
        #nullable disable

/// <summary>
        /// PNRTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? PNRTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// PNRActive.
        /// </summary>
        
        #nullable enable
        public bool? PNRActive { set; get; }
        #nullable disable


    }
}




