using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Deals
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// HotelRoomId.
        /// </summary>
        public string HotelRoomId { set; get; }


        /// <summary>
        /// BoardTypeId.
        /// </summary>
        public string BoardTypeId { set; get; }


        /// <summary>
        /// DealTypeId.
        /// </summary>
        public string DealTypeId { set; get; }


        /// <summary>
        /// Release.
        /// </summary>
        public string Release { set; get; }


        /// <summary>
        /// Discount.
        /// </summary>
        public decimal Discount { set; get; }


        /// <summary>
        /// FreeNights.
        /// </summary>
        public string FreeNights { set; get; }


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