using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class HotelRooms
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
        /// RoomId.
        /// </summary>
        public string RoomId { set; get; }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// Adults.
        /// </summary>
        public string Adults { set; get; }


        /// <summary>
        /// Children.
        /// </summary>
        public string Children { set; get; }


        /// <summary>
        /// Infants.
        /// </summary>
        public string Infants { set; get; }


    }
}