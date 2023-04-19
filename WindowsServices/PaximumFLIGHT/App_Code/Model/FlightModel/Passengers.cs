using System;

namespace Model.FlightModels.Concrete
{
    public class Passengers
    {
        public int Id { get; set; }
        public int PassengerTypesId { get; set; }
        public int Count { get; set; }

        public int Ages { get; set; }
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
