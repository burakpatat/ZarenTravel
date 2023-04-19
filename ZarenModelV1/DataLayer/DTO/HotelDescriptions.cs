using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class HotelDescriptions
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// HotelId.
        /// </summary>
        public string HotelId { set; get; }


        /// <summary>
        /// LanguageId.
        /// </summary>
        public string LanguageId { set; get; }


        /// <summary>
        /// Description.
        /// </summary>
        public string Description { set; get; }


    }
}