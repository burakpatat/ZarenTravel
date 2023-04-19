using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ExtensionsUpdate
    {
        public int ID { get; set; }

        public int? FileType { get; set; }

        public string ExtensionName { get; set; }

        public string KeyName { get; set; }

        public string FilePath { get; set; }

        public bool? IsRealName { get; set; }

    }
}