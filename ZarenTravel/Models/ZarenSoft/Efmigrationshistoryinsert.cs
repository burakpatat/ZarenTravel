using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class Efmigrationshistoryinsert
    {
        public string MigrationId { get; set; }

        public string ProductVersion { get; set; }

    }
}