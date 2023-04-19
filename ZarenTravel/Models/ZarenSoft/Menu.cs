using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Menu", Schema = "dbo")]
    public partial class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        public string TitleEng { get; set; }

        public string TitleArabic { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

    }
}