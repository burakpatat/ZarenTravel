using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Provience", Schema = "dbo")]
    public partial class Provience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public int? CityID { get; set; }

        public int? Statu { get; set; }

        public int? TableOrder { get; set; }

        public string Information { get; set; }

        public string ListImage { get; set; }

    }
}