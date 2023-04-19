using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetDependency
    {
        public string USED_OBJECT { get; set; }

        public string COLUMN { get; set; }

        public string USAGE_OBJECT { get; set; }

        public string USAGE_OBJECTTYPE { get; set; }

        public string USAGE_OBJECTTYPEID { get; set; }

    }
}