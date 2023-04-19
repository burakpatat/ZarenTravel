using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelTypes", Schema = "dbo")]
    public partial class HotelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<HotelTypeLanguage> HotelTypeLanguages { get; set; }

        public ICollection<Hotel1> Hotel1S { get; set; }

    }
}