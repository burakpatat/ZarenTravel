using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Zones", Schema = "dbo")]
    public partial class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? RegionId { get; set; }

        public string Name { get; set; }

        public string LatLongBounds { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public Region Region { get; set; }

        public ICollection<ZonesCity> ZonesCities { get; set; }

        public ICollection<Hotel1> Hotel1S { get; set; }

    }
}