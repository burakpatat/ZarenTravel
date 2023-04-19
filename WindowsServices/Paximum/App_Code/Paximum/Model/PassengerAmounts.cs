using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Paximum.Response.OfferDetail;

namespace Model.Concrete
{
    [Table("PassengerAmounts")]
    public class PassengerAmounts
    {
        [Key]
        public int Id { get; set; }
        public string SystemId { get; set; }
        public int CurrencyId { get; set; }
        public int OfferId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int? ApiId { get; set; }
        public int? AgencyId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Type { get; set; }

    }
}
