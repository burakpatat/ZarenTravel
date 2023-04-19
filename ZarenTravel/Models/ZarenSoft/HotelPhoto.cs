using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelPhotos", Schema = "dbo")]
    public partial class HotelPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? HotelRoomId { get; set; }

        public string Path { get; set; }

        public int? Order { get; set; }

        public ICollection<HotelPhotoLanguage> HotelPhotoLanguages { get; set; }

        public Hotel Hotel { get; set; }

        public HotelRoom HotelRoom { get; set; }

    }
}