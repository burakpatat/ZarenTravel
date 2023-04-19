using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class UserPreferencesInsert
    {
        public int ID { get; set; }

        public int? ThemeStyle { get; set; }

        public int? UserID { get; set; }

        public int? Products { get; set; }

        public int? HeaderColor { get; set; }

        public int? SideBarColor { get; set; }

    }
}