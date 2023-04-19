using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetViewList
    {
        public string view_schema { get; set; }

        public string view_name { get; set; }

        public string view_definition { get; set; }

    }
}