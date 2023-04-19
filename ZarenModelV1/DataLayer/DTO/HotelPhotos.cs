using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class HotelPhotos
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
        /// HotelRoomId.
        /// </summary>
        public string HotelRoomId { set; get; }


        /// <summary>
        /// Path.
        /// </summary>
        public string Path { set; get; }


        /// <summary>
        /// Order.
        /// </summary>
        public string Order { set; get; }


    }
}