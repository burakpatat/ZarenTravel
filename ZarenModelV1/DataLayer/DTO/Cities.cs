using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Cities
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
        /// Latitude.
        /// </summary>
        public decimal Latitude { set; get; }


        /// <summary>
        /// Longitude.
        /// </summary>
        public decimal Longitude { set; get; }


    }
}