using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Shared.HotelModels
{
    public class HotelQueryDTO
    {
        public string HotelId { get; set; }
        public int NumberOfTravellers { get; set; }
        public string OfferIds { get; set; }
    }
}
