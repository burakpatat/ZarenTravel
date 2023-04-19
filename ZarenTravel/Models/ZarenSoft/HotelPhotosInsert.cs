using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelPhotosInsert
    {
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? HotelRoomId { get; set; }

        public string Path { get; set; }

        public int? Order { get; set; }

    }
}