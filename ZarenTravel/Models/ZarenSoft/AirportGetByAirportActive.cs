using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class AirportGetByAirportActive
    {
        public int Id { get; set; }

        public string AirportCode { get; set; }

        public string AirportName { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public DateTime? AirportTimestamp { get; set; }

        public bool? AirportActive { get; set; }

    }
}