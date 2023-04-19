using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlaceFees", Schema = "dbo")]
    public partial class MarketPlaceFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MarketPlaceProfileId { get; set; }

        public int? ProductId { get; set; }

        public int? Amount { get; set; }

        public int? CurrencyId { get; set; }

        public bool? ByPercentage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? MarketPlaceTypeId { get; set; }

        public int? TargetMarketPlaceProfileId { get; set; }

        public int? AgencyUserId { get; set; }

        public int? ServiceTypeId { get; set; }

        public bool? DontChargeToFinalPrice { get; set; }

        public decimal? FromMsFee { get; set; }

        public decimal? FromOpFee { get; set; }

        public int? LimitTypeId { get; set; }

        public MarketPlacesProfile MarketPlacesProfile { get; set; }

    }
}