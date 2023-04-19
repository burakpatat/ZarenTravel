using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Segments", Schema = "dbo")]
    public partial class Segment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FlightNo { get; set; }

        public string PnlName { get; set; }

        public int? FlightClassesId { get; set; }

        public int? DepartureId { get; set; }

        public int? ArrivalId { get; set; }

        public int? AirLinesId { get; set; }

        public int? MarketingAirlineId { get; set; }

        public int? ItemsId { get; set; }

        public int? Duration { get; set; }

        public string AirCraft { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? FlightId { get; set; }

        public int? SegmentId { get; set; }

    }
}