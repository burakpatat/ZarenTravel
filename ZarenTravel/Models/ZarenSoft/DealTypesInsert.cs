using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DealTypesInsert
    {
        public int Id { get; set; }

        public int? Name { get; set; }

    }
}