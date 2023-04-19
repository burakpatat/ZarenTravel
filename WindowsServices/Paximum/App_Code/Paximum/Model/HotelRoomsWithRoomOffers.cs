using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Paximum.Response.OfferDetail;

namespace Model.Concrete
{
    [Table("HotelRoomsWithRoomOffers")]
    public class HotelRoomsWithRoomOffers
    {
        [Key]
        public int Id { get; set; }
        public int RoomsId { get; set; }
        public int RoomOffersId { get; set; }
        public float PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
