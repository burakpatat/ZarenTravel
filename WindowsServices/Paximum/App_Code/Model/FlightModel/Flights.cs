using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class Flights
    {
        public int Id { get; set; }
        public int Provider { get; set; }
        public int AvailableSeatCount { get; set; }
        public int AvailableSeatCountType { get; set; }
        public ICollection<FlightItems> Items { get; set; }
        public ICollection<Offers> Offers { get; set; }
        public ICollection<GroupKeys> GroupKeys { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
