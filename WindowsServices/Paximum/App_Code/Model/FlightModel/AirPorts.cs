using System;

namespace Model.FlightModels.Concrete
{
    public class AirPorts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int GeoLocationId { get; set; }
        public FlightGeoLocation GeoLocation { get; set; }
        public FlightItems Items { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
