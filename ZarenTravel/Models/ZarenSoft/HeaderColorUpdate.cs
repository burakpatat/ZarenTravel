using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HeaderColorUpdate
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Path { get; set; }

    }
}