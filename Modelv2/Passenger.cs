using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Passenger
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// PassengerFullName.
        /// </summary>
        
        #nullable enable
        public string? PassengerFullName { set; get; }
        #nullable disable

/// <summary>
        /// PassengerPhone.
        /// </summary>
        
        #nullable enable
        public string? PassengerPhone { set; get; }
        #nullable disable

/// <summary>
        /// PassengerCelPhone.
        /// </summary>
        
        #nullable enable
        public string? PassengerCelPhone { set; get; }
        #nullable disable

/// <summary>
        /// PassengerEmail.
        /// </summary>
        
        #nullable enable
        public string? PassengerEmail { set; get; }
        #nullable disable

/// <summary>
        /// PassengerJobPosition.
        /// </summary>
        
        #nullable enable
        public string? PassengerJobPosition { set; get; }
        #nullable disable

/// <summary>
        /// PassengerVIP.
        /// </summary>
        
        #nullable enable
        public bool? PassengerVIP { set; get; }
        #nullable disable

/// <summary>
        /// PassemgerTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? PassemgerTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// PassengerActive.
        /// </summary>
        
        #nullable enable
        public bool? PassengerActive { set; get; }
        #nullable disable


    }
}




