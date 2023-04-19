using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class FlightItems
    {
        public int Id { get; set; }
        public int SegmentNumber { get; set; }
        public string FlightNo { get; set; }
        public string PnlName { get; set; }
        public DateTime FlightDate { get; set; }
        public int DeparturesDeparturesArrivalsId { get; set; } 
        public DeparturesArrivals DeparturesDeparturesArrivals { get; set; }
        public int AirLinesId { get; set; }
        public AirLines AirLines { get; set; }
        public int MarketingAirlines { get; set; }
        public int FlightClassesId { get; set; }
        public FlightClasses FlightClasses { get; set; }

        public FlightProviders FlightProviders { get; set; }
        public int Duration { get; set; }
        public int DayChange { get; set; }
        public int Route { get; set; }
        public int StopCount { get; set; }
        public int FlightType { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int AirPortsId { get; set; }
        public AirPorts AirPorts { get; set; }
        public Flights Flights { get; set; }
        public ICollection<Segments> Segments { get; set; }
        public ICollection<BaggageInformations> BaggageInformations { get; set; }
        public ICollection<Passengers> Passengers { get; set; }      

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
