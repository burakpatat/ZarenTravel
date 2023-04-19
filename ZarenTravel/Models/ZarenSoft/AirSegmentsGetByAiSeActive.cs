using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class AirSegmentsGetByAiSeActive
    {
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

    }
}