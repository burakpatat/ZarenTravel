using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelBuyRoomsInsert
    {
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? BuyRoomId { get; set; }

    }
}