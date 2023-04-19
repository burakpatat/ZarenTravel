using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelRoomLanguages", Schema = "dbo")]
    public partial class HotelRoomLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelRoomId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public HotelRoom HotelRoom { get; set; }

        public Language Language { get; set; }

    }
}