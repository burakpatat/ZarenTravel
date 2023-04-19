using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Model
{
    [Table("HotelBuyRoomAllotment")]
    public class Hotelbuyroomallotment
    {
        public int Id { get; set; }
        public int? HotelBuyRoomId { get; set; }
        public DateTime? Day { get; set; }
        public int? Allotment { get; set; }
        public int? Release { get; set; }
        public int? StopSales { get; set; }
    }
}

