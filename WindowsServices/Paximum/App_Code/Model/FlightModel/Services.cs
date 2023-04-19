using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailFull { get; set; }
        public int ExplanationsId { get; set; }
        public ICollection<Segments> Segments { get; set; }
        public Explanations Explanations { get; set; }
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
