using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Providers
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// Address.
        /// </summary>
        public string Address { set; get; }


        /// <summary>
        /// Website.
        /// </summary>
        public string Website { set; get; }


        /// <summary>
        /// ComercialContactId.
        /// </summary>
        public string ComercialContactId { set; get; }


        /// <summary>
        /// ReservationContactId.
        /// </summary>
        public string ReservationContactId { set; get; }


        /// <summary>
        /// FinanceContactId.
        /// </summary>
        public string FinanceContactId { set; get; }


    }
}