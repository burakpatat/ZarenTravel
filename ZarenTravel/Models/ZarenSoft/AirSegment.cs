using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AirSegments", Schema = "dbo")]
    public partial class AirSegment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AirId { get; set; }

        public int? AirlineId { get; set; }

        public DateTime? AiSeDeparture { get; set; }

        public DateTime? AiSeArrival { get; set; }

        public int? AirportIdOrigin { get; set; }

        public int? AirportIdDestination { get; set; }

        public string AiSeFlightNumber { get; set; }

        public bool? AiSeClass { get; set; }

        public int? TerminalIdOrigin { get; set; }

        public int? TerminalIdDestination { get; set; }

        public DateTime? AiSeTimestamp { get; set; }

        public bool? AiSeActive { get; set; }

        public Air Air { get; set; }

        public Airline Airline { get; set; }

        public Airport Airport { get; set; }

        public Airport Airport1 { get; set; }

        public Terminal Terminal { get; set; }

        public Terminal Terminal1 { get; set; }

    }
}