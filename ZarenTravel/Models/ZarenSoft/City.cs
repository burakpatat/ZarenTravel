using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Cities", Schema = "dbo")]
    public partial class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<ZonesCity> ZonesCities { get; set; }

        public ICollection<Hotel1> Hotel1S { get; set; }

    }
}