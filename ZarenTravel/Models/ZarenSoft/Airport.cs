using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Airport", Schema = "dbo")]
    public partial class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AirportCode { get; set; }

        public string AirportName { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public DateTime? AirportTimestamp { get; set; }

        public bool? AirportActive { get; set; }

        public Country Country { get; set; }

        public ICollection<AirSegment> AirSegments { get; set; }

        public ICollection<AirSegment> AirSegments1 { get; set; }

        public ICollection<CarRent> CarRents { get; set; }

        public ICollection<CarRent> CarRents1 { get; set; }

        public ICollection<Terminal> Terminals { get; set; }

    }
}