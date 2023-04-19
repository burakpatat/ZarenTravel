using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class Regions
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// CountryId.
        /// </summary>
        public string CountryId { set; get; }


        /// <summary>
        /// Name.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// LatLongBounds.
        /// </summary>
        public string LatLongBounds { set; get; }


    }
}