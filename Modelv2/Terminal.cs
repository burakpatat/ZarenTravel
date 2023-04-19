using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class Terminal
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// TerminalName.
        /// </summary>
        
        #nullable enable
        public string? TerminalName { set; get; }
        #nullable disable

/// <summary>
        /// TerminalCode.
        /// </summary>
        
        #nullable enable
        public string? TerminalCode { set; get; }
        #nullable disable

/// <summary>
        /// AirportId.
        /// </summary>
        
        #nullable enable
        public string? AirportId { set; get; }
        #nullable disable

/// <summary>
        /// TerminalTimestamp.
        /// </summary>
        
        #nullable enable
        public DateTime? TerminalTimestamp { set; get; }
        #nullable disable

/// <summary>
        /// TerminalActive.
        /// </summary>
        
        #nullable enable
        public bool? TerminalActive { set; get; }
        #nullable disable


    }
}




