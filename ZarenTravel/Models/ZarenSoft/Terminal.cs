using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Terminal", Schema = "dbo")]
    public partial class Terminal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TerminalName { get; set; }

        public string TerminalCode { get; set; }

        public int? AirportId { get; set; }

        public DateTime? TerminalTimestamp { get; set; }

        public bool? TerminalActive { get; set; }

        public ICollection<AirSegment> AirSegments { get; set; }

        public ICollection<AirSegment> AirSegments1 { get; set; }

        public Airport Airport { get; set; }

    }
}