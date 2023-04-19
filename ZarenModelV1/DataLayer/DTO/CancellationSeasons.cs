using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class CancellationSeasons
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
        /// StartDate.
        /// </summary>
        public DateTime StartDate { set; get; }


        /// <summary>
        /// EndDate.
        /// </summary>
        public DateTime EndDate { set; get; }


    }
}