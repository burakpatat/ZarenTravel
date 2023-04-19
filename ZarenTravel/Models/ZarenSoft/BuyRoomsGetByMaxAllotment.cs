using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class BuyRoomsGetByMaxAllotment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? MaxAllotment { get; set; }

        public int? MaxAdults { get; set; }

        public int? MaxChildren { get; set; }

        public int? MaxInfants { get; set; }

    }
}