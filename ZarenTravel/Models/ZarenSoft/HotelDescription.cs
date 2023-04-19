using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelDescriptions", Schema = "dbo")]
    public partial class HotelDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? LanguageId { get; set; }

        public string Description { get; set; }

        public Hotel Hotel { get; set; }

        public Language Language { get; set; }

    }
}