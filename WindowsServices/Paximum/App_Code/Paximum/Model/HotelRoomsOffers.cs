using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Paximum.Response.OfferDetail;

namespace Model.Concrete
{
    [Table("HotelRoomsOffers")]
    public class HotelRoomsOffers
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public bool IsAvilable { get; set; }
        public bool IsRefundable { get; set; }
        public int Night { get; set; }
        public string OfferId { get; set; }
        public bool OwnOffer { get; set; }
        public float PriceAmount { get; set; }
        public string PriceCurrency { get; set; }

    }
}
