using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.DTO
{
    public class CancellationRules
    {
        
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// CancellationSeasonId.
        /// </summary>
        public string CancellationSeasonId { set; get; }


        /// <summary>
        /// Cost.
        /// </summary>
        public decimal Cost { set; get; }


        /// <summary>
        /// CostType.
        /// </summary>
        public string CostType { set; get; }


        /// <summary>
        /// FromDays.
        /// </summary>
        public string FromDays { set; get; }


        /// <summary>
        /// ToDays.
        /// </summary>
        public string ToDays { set; get; }


    }
}