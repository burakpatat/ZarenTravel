using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetModifyDate
    {
        public string name { get; set; }

        public string type { get; set; }

        public DateTime create_date { get; set; }

        public DateTime modify_date { get; set; }

    }
}