using System;

namespace Model.FlightModels.Concrete
{
    public class BaggageUnitTypes
    {
        public int Id { get; set; }
        public string Descriptions { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
