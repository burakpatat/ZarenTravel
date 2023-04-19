using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyContractsHotelInformationImage", Schema = "dbo")]
    public partial class AgencyContractsHotelInformationImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string ImagePath { get; set; }

    }
}