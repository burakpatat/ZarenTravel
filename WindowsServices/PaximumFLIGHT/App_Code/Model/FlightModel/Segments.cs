using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete { 
    public class Segments
    {
        public int Id { get; set; }
        public string FlightNo { get; set; }
        public string PnlName { get;set; }
        public int FlightClassesId { get; set; }
        public int DeparturesArrivalsId { get; set; }
        public DeparturesArrivals DeparturesArrivals { get; set; }
        public int AirLinesId { get; set; }
        public AirLines AirLines { get; set; }
        public FlightItems Items { get; set; }
        public FlightClasses FlightClasses { get; set; }

        public int Duration { get; set; }
        public ICollection<BaggageInformations> BaggageInformations { get; set; }
        public ICollection<Services> Services { get; set; }
        public string AirCraft { get; set; }


        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
