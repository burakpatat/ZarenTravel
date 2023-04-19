using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsHotelInformationImage", Schema = "zaren")]
    public partial class AgencyContractsHotelInformationImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string ImagePath { get; set; }

    }
}