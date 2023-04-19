using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Airs", Schema = "dbo")]
    public partial class Air
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AirlineId { get; set; }

        public string AirRecordAirline { get; set; }

        public string AirTicket { get; set; }

        public DateTime? AirBookedDate { get; set; }

        public DateTime? AirIssueddate { get; set; }

        public bool? AirReIssued { get; set; }

        public string AirOriginalTicket { get; set; }

        public int? PNRId { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? AirFare { get; set; }

        public decimal? AirTax { get; set; }

        public decimal? AirLowestFare { get; set; }

        public decimal? AirHighestFare { get; set; }

        public string AirFareBases { get; set; }

        public int? BrokerId { get; set; }

        public bool? AirIncludeBags { get; set; }

        public DateTime? AirTimestamp { get; set; }

        public bool? AirActive { get; set; }

        public ICollection<AirExtra> AirExtras { get; set; }

        public Airline Airline { get; set; }

        public Broker Broker { get; set; }

        public Currency1 Currency1 { get; set; }

        public PnR Pnr { get; set; }

        public ICollection<AirSegment> AirSegments { get; set; }

    }
}