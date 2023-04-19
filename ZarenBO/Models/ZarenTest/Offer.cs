using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Offers", Schema = "dbo")]
    public partial class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SystemId { get; set; }

        public int? Night { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Availability { get; set; }

        public int? OfferRoomsId { get; set; }

        public bool? IsRefundable { get; set; }

        public string OfferId { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public int? PriceId { get; set; }

        public bool? OwnOffer { get; set; }

        public int? Provider { get; set; }

        public DateTime? ExpiresOn { get; set; }

        public int? OfferCancellationPolicyId { get; set; }

        public int? OfferPriceBreakDownId { get; set; }

        public bool? IsSpecial { get; set; }

        public int? AgencyCommissionId { get; set; }

        public int? AgencySupplementCommissionId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public string PriceCurrency { get; set; }

        public double? PriceAmount { get; set; }

    }
}