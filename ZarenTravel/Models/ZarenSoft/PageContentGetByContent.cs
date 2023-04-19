using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class PageContentGetByContent
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public string Image { get; set; }

        public int? LanguageID { get; set; }

        public int? TableOrder { get; set; }

        public DateTime? CreateDate { get; set; }

        public string PageUrl { get; set; }

        public string SubTitle { get; set; }

    }
}