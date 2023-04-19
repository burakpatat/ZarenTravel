using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Facilities", Schema = "dbo")]
    public partial class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<FacilitiesHotel> FacilitiesHotels { get; set; }

        public ICollection<FacilityLanguage> FacilityLanguages { get; set; }

    }
}