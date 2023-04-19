using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class FlightBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public ICollection<Features> Features { get; set; }
        public Offers Offers { get; set; }
    }
}
