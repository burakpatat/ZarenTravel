using System;

namespace Model.FlightModels.Concrete
{
    public class DeparturesArrivals
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public AirPorts AirPorts { get; set; }
        public int GeoLocationId { get; set; }
        public FlightItems Items { get; set; }
        public Segments Segments { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
