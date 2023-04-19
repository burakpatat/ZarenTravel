using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Regions", Schema = "dbo")]
    public partial class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CountryId { get; set; }

        public string Name { get; set; }

        public string LatLongBounds { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<Zone> Zones { get; set; }

        public ICollection<Hotel1> Hotel1S { get; set; }

    }
}