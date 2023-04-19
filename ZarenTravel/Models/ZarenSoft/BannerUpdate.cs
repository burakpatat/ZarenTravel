using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class BannerUpdate
    {
        public int ID { get; set; }

        public int? LanguageID { get; set; }

        public string ImagePath { get; set; }

        public string MobileImagePath { get; set; }

        public int? TableOrder { get; set; }

        public string Text { get; set; }

        public string Text2 { get; set; }

        public string Text3 { get; set; }

    }
}