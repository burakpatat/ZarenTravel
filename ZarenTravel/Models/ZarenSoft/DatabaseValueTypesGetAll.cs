using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DatabaseValueTypesGetAll
    {
        public int ID { get; set; }

        public string FrontEndName { get; set; }

        public string SqlName { get; set; }

    }
}