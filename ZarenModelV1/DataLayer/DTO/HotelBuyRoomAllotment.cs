using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class HotelBuyRoomAllotment
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// HotelBuyRoomId.
        /// </summary>
        public string HotelBuyRoomId { set; get; }


        /// <summary>
        /// Day.
        /// </summary>
        public DateTime Day { set; get; }


        /// <summary>
        /// Allotment.
        /// </summary>
        public string Allotment { set; get; }


        /// <summary>
        /// Release.
        /// </summary>
        public string Release { set; get; }


        /// <summary>
        /// StopSales.
        /// </summary>
        public string StopSales { set; get; }


    }
}