using System;

namespace Model.FlightModels.Concrete
{
    public class FlightClasses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
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
