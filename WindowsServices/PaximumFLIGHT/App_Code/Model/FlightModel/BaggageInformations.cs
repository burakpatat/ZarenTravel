using System;

namespace Model.FlightModels.Concrete
{
    public class BaggageInformations
    {
        public int Id { get; set; }
        public int SegmentsId { get; set; }
        public int Weight { get; set; }
        public int Piece { get; set; }
        public int BaggageTypesId { get; set; }
        public int BaggageUnitTypesId { get; set; }
        public int PassengerTypesId { get; set; }
        public string Descriptions { get; set; }
        public FlightItems Items { get; set; }
        public Segments Segments { get; set; }
        public Offers Offers { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
