using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlaceSellingDestinations", Schema = "dbo")]
    public partial class MarketPlaceSellingDestination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public int? City { get; set; }

        public int? Country { get; set; }

        public int? TableOrder { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public MarketPlacesProfile MarketPlacesProfile { get; set; }

    }
}