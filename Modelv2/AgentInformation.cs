using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AgentInformation
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        
        public string Id { set; get; }
        

/// <summary>
        /// AgentCode.
        /// </summary>
        
        
        public string AgentCode { set; get; }
        

/// <summary>
        /// AgentName.
        /// </summary>
        
        #nullable enable
        public string? AgentName { set; get; }
        #nullable disable

/// <summary>
        /// AgentStation.
        /// </summary>
        
        #nullable enable
        public string? AgentStation { set; get; }
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




