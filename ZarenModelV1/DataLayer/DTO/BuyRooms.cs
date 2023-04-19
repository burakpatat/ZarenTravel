using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class BuyRooms
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
        /// Description.
        /// </summary>
        public string Description { set; get; }


        /// <summary>
        /// MaxAllotment.
        /// </summary>
        public string MaxAllotment { set; get; }


        /// <summary>
        /// MaxAdults.
        /// </summary>
        public string MaxAdults { set; get; }


        /// <summary>
        /// MaxChildren.
        /// </summary>
        public string MaxChildren { set; get; }


        /// <summary>
        /// MaxInfants.
        /// </summary>
        public string MaxInfants { set; get; }


    }
}