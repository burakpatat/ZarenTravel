using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Languages", Schema = "dbo")]
    public partial class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BoardTypeLanguage> BoardTypeLanguages { get; set; }

        public ICollection<CancelationLanguage> CancelationLanguages { get; set; }

        public ICollection<Company> Companies { get; set; }

        public ICollection<DealTypeLanguage> DealTypeLanguages { get; set; }

        public ICollection<FacilityLanguage> FacilityLanguages { get; set; }

        public ICollection<HotelDescription> HotelDescriptions { get; set; }

        public ICollection<HotelPhotoLanguage> HotelPhotoLanguages { get; set; }

        public ICollection<HotelRoomLanguage> HotelRoomLanguages { get; set; }

        public ICollection<HotelTypeLanguage> HotelTypeLanguages { get; set; }

    }
}