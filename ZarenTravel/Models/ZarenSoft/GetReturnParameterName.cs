using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetReturnParameterName
    {
        public string name { get; set; }

        public string system_type_name { get; set; }

        public bool? is_identity_column { get; set; }

    }
}