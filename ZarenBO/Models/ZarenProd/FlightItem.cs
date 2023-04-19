using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("FlightItems", Schema = "dbo")]
    public partial class FlightItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ProductType { get; set; }

        public string ServiceTypes { get; set; }

        public int? SegmentNumber { get; set; }

        public string FlightNo { get; set; }

        public string PnlName { get; set; }

        public DateTime? FlightDate { get; set; }

        public int? ArrivalsId { get; set; }

        public int? DeparturesId { get; set; }

        public string AirLinesId { get; set; }

        public string MarketingAirlines { get; set; }

        public int? FlightClassesId { get; set; }

        public string FlightClassesSystemId { get; set; }

        public int? Duration { get; set; }

        public int? DayChange { get; set; }

        public int? Route { get; set; }

        public int? StopCount { get; set; }

        public int? FlightType { get; set; }

        public int? FlightProviderId { get; set; }

        public int? FlightsId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}