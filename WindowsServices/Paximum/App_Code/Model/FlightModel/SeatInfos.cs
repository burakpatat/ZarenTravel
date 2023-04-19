using System;

namespace Model.FlightModels.Concrete
{
    public class SeatInfos
    {
        public int Id { get; set; }
        public int AvailableSeatCount { get; set; }
        public int AvailableSeatCountTypeId { get; set; }
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
