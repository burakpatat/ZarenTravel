using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Paximum.Response.OfferDetail;

namespace Model.Concrete
{
    [Table("HotelRooms")]
    public class HotelRooms
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string BoardId { get; set; }
        public string BoardName { get; set; }
        public string RoomInfoId { get; set; }
        public int HotelId { get; set; }
        public string Code { get; set; }

        public string SystemId { get; set; }

        public int? LanguageId { get; set; }

        public int? ApiId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Type { get; set; }

    }
}
