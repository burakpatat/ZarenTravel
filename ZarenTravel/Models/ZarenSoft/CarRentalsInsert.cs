using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CarRentalsInsert
    {
        public int Id { get; set; }

        public string CaRtCode { get; set; }

        public string CaRtName { get; set; }

        public DateTime? CaRtTimestamp { get; set; }

        public bool? CaRtActive { get; set; }

    }
}