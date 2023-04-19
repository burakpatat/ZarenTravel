using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ZonesCities", Schema = "dbo")]
    public partial class ZonesCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CityId { get; set; }

        public int? ZoneId { get; set; }

        public string MainZone { get; set; }

        public City City { get; set; }

        public Zone Zone { get; set; }

    }
}