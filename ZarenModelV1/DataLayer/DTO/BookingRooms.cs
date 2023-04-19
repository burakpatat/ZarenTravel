using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class BookingRooms
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// BookingId.
        /// </summary>
        public string BookingId { set; get; }


        /// <summary>
        /// HotelRoomId.
        /// </summary>
        public string HotelRoomId { set; get; }


        /// <summary>
        /// BoardTypeId.
        /// </summary>
        public string BoardTypeId { set; get; }


        /// <summary>
        /// Cost.
        /// </summary>
        public decimal Cost { set; get; }


        /// <summary>
        /// Price.
        /// </summary>
        public string Price { set; get; }


    }
}