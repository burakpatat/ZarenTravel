using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Airline", Schema = "dbo")]
    public partial class Airline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AirlineCode { get; set; }

        public string AirlineName { get; set; }

        public string AirlinePlate { get; set; }

        public DateTime? AirlineTimestamp { get; set; }

        public bool? AirlineActive { get; set; }

        public ICollection<Air> Airs { get; set; }

        public ICollection<AirSegment> AirSegments { get; set; }

    }
}