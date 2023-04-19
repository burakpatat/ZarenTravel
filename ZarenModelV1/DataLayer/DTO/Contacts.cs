using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Contacts
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// TelNumber.
        /// </summary>
        public string TelNumber { set; get; }


        /// <summary>
        /// FaxNumber.
        /// </summary>
        public string FaxNumber { set; get; }


        /// <summary>
        /// Email.
        /// </summary>
        public string Email { set; get; }


    }
}