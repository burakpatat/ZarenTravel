using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
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

    }
}