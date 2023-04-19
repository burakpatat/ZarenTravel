using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class OgSeoGetByseoDescription
    {
        public int ID { get; set; }

        public int? PageType { get; set; }

        public int? PageID { get; set; }

        public string ogImage { get; set; }

        public string ogDescription { get; set; }

        public string ogTitle { get; set; }

        public string seoTitle { get; set; }

        public string seoKeyword { get; set; }

        public string seoDescription { get; set; }

    }
}