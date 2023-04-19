using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Hotels
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// HotelChainId.
        /// </summary>
        public string HotelChainId { set; get; }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// HotelTypeId.
        /// </summary>
        public string HotelTypeId { set; get; }


        /// <summary>
        /// CountryId.
        /// </summary>
        public string CountryId { set; get; }


        /// <summary>
        /// RegionId.
        /// </summary>
        public string RegionId { set; get; }


        /// <summary>
        /// ZoneId.
        /// </summary>
        public string ZoneId { set; get; }


        /// <summary>
        /// CityId.
        /// </summary>
        public string CityId { set; get; }


        /// <summary>
        /// Address.
        /// </summary>
        public string Address { set; get; }


        /// <summary>
        /// ZipCode.
        /// </summary>
        public string ZipCode { set; get; }


        /// <summary>
        /// Latitude.
        /// </summary>
        public decimal Latitude { set; get; }


        /// <summary>
        /// Longitude.
        /// </summary>
        public decimal Longitude { set; get; }


        /// <summary>
        /// CommercialContactId.
        /// </summary>
        public string CommercialContactId { set; get; }


        /// <summary>
        /// ReservationContactId.
        /// </summary>
        public string ReservationContactId { set; get; }


        /// <summary>
        /// FinanceContactId.
        /// </summary>
        public string FinanceContactId { set; get; }


        /// <summary>
        /// Release.
        /// </summary>
        public string Release { set; get; }


        /// <summary>
        /// NumberRooms.
        /// </summary>
        public string NumberRooms { set; get; }


    }
}