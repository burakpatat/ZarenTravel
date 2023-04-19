using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class AutoCompletesGetAll
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Type { get; set; }

        public int? ApiId { get; set; }

        public string ApiSystemId { get; set; }

    }
}