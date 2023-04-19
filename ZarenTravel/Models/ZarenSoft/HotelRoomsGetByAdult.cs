using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelRoomsGetByAdult
    {
        public int Id { get; set; }

        public int? HotelBuyRoomId { get; set; }

        public int? RoomId { get; set; }

        public string Name { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }

        public int? Infants { get; set; }

    }
}