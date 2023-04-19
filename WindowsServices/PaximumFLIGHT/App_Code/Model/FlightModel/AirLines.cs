using System;

namespace Model.FlightModels.Concrete
{
    public class AirLines
    {
        public int Id { get; set; }
        public bool IsMarketing { get; set; }
        public string InterNationalCode { get; set; }
        public string Thumbnail { get; set;}
        public string ThumbnailFull { get;set; }
        public string Logo { get;set; }
        public string LogoFull { get; set;}
        public string Name { get; set;}
        public int ItemsId { get; set; }
        //public int SegmentsId { get; set; }
        public FlightItems FlightItems { get; set; }
        public Segments Segments { get; set; }


        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
