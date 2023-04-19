using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlacesProfiles", Schema = "dbo")]
    public partial class MarketPlacesProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        [Required]
        public string Descriptions { get; set; }

        public string Website { get; set; }

        public int? SourceMarketCountryId { get; set; }

        public string Logo { get; set; }

        public bool? AcceptSupplier { get; set; }

        public bool? AcceptReseller { get; set; }

        public bool? AcceptProducts { get; set; }

        public int? MarketPlaceTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public ICollection<MarketPlaceBuyingDestination> MarketPlaceBuyingDestinations { get; set; }

        public ICollection<MarketPlaceFee> MarketPlaceFees { get; set; }

        public ICollection<MarketPlaceSellingDestination> MarketPlaceSellingDestinations { get; set; }

        public MarketPlaceType MarketPlaceType { get; set; }

        public MarketPlacesProfile MarketPlacesProfile1 { get; set; }

        public ICollection<MarketPlacesProfile> MarketPlacesProfiles1 { get; set; }

    }
}