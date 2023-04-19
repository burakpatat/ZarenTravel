using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class HotelRoomDailyPrices
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// BoardTypeId.
        /// </summary>
        public string BoardTypeId { set; get; }


        /// <summary>
        /// HotelRoomId.
        /// </summary>
        public string HotelRoomId { set; get; }


        /// <summary>
        /// Cost.
        /// </summary>
        public string Cost { set; get; }


        /// <summary>
        /// Day.
        /// </summary>
        public DateTime Day { set; get; }


        /// <summary>
        /// StopSale.
        /// </summary>
        public string StopSale { set; get; }


    }
}