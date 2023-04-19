using System;
using System.Collections;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class FlightOffers
    {
        public int Id { get; set; }
        public int FlightsId { get; set; }
        public Flights Flights { get; set; }
        public int SegmentNumber { get; set; }
        public bool IsPackageOffer { get; set; }
        public int Route { get; set; }
        public int Provider { get; set; }
        public ICollection<FlightClasses> FlightClasses { get; set; }
        public ICollection<BaggageInformations> BaggageInformations { get; set; }
        public ICollection<GroupKeys>  GroupKeys { get; set; }
        public FlightBrands FlightBrands { get; set; }
        public int  PricesId { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
