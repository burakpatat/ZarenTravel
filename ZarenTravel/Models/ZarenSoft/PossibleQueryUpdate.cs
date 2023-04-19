using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class PossibleQueryUpdate
    {
        public int Id { get; set; }

        public string Query { get; set; }

    }
}