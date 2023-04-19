using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Bookings
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
        /// ProviderId.
        /// </summary>
        public string ProviderId { set; get; }


        /// <summary>
        /// AgencyId.
        /// </summary>
        public string AgencyId { set; get; }


        /// <summary>
        /// Reference.
        /// </summary>
        public string Reference { set; get; }


        /// <summary>
        /// FromDate.
        /// </summary>
        public DateTime FromDate { set; get; }


        /// <summary>
        /// ToDate.
        /// </summary>
        public DateTime ToDate { set; get; }


        /// <summary>
        /// DateBooked.
        /// </summary>
        public DateTime DateBooked { set; get; }


        /// <summary>
        /// Nights.
        /// </summary>
        public string Nights { set; get; }


        /// <summary>
        /// NumRooms.
        /// </summary>
        public string NumRooms { set; get; }


        /// <summary>
        /// TotalCost.
        /// </summary>
        public decimal TotalCost { set; get; }


        /// <summary>
        /// TotalPrice.
        /// </summary>
        public decimal TotalPrice { set; get; }


        /// <summary>
        /// Status.
        /// </summary>
        public string Status { set; get; }


        /// <summary>
        /// PaidStatus.
        /// </summary>
        public string PaidStatus { set; get; }


        /// <summary>
        /// ClientTitle.
        /// </summary>
        public string ClientTitle { set; get; }


        /// <summary>
        /// ClientName.
        /// </summary>
        public string ClientName { set; get; }


        /// <summary>
        /// ClientSurname.
        /// </summary>
        public string ClientSurname { set; get; }


        /// <summary>
        /// ClientEmail.
        /// </summary>
        public string ClientEmail { set; get; }


        /// <summary>
        /// ClientNotes.
        /// </summary>
        public string ClientNotes { set; get; }


        /// <summary>
        /// Clientaddress.
        /// </summary>
        public string Clientaddress { set; get; }


        /// <summary>
        /// ClientContact.
        /// </summary>
        public string ClientContact { set; get; }


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


        /// <summary>
        /// ChildrenAges.
        /// </summary>
        public string ChildrenAges { set; get; }


    }
}