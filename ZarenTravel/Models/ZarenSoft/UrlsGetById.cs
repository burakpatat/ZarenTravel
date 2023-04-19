using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class UrlsGetById
    {
        public int ID { get; set; }

        public string FriendlyUrl { get; set; }

        public int? PageID { get; set; }

        public string PageName { get; set; }

        public int? PageView { get; set; }

        public int? LanguageID { get; set; }

        public int? IsDefault { get; set; }

    }
}