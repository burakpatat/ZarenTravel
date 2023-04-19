using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ZonesCitiesInsert
    {
        public int Id { get; set; }

        public int? CityId { get; set; }

        public int? ZoneId { get; set; }

        public string MainZone { get; set; }

    }
}