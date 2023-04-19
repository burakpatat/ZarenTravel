using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Broker
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// BrokerCode.
        /// </summary>
        
        #nullable enable
        public string? BrokerCode { set; get; }
        #nullable disable

/// <summary>
        /// BrokerName.
        /// </summary>
        
        #nullable enable
        public string? BrokerName { set; get; }
        #nullable disable

/// <summary>
        /// BrokerTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? BrokerTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// BrokerActive.
        /// </summary>
        
        #nullable enable
        public bool? BrokerActive { set; get; }
        #nullable disable


    }
}




