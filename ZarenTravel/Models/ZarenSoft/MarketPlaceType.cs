using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlaceType", Schema = "dbo")]
    public partial class MarketPlaceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MarketPlacesProfile> MarketPlacesProfiles { get; set; }

    }
}