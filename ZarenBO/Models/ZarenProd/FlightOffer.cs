using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("FlightOffers", Schema = "dbo")]
    public partial class FlightOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ExpiresOn { get; set; }

        public string OfferId { get; set; }

        public decimal? Price { get; set; }

        public decimal? SingleAdultPrice { get; set; }

        public decimal? ServiceFeesAmount { get; set; }

        public int? CurrencyId { get; set; }

        public int? SegmentNumber { get; set; }

        public bool? IsPackageOffer { get; set; }

        public bool? HasBrand { get; set; }

        public int? Route { get; set; }

        public int? Provider { get; set; }

        public int? SeatInfosSeatCount { get; set; }

        public int? SeatInfosSeatCountType { get; set; }

        public string GroupKey { get; set; }

        public int? PriceBreakDownId { get; set; }

        public bool? ReservableInfo { get; set; }

        public int? FlightsId { get; set; }

        public int? FlightProviderId { get; set; }

        public int? FlightBrandsId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}