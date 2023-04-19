using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsConfigurationByHotel", Schema = "zaren")]
    public partial class AgencyContractsConfigurationByHotel
    {
        public int? MicroSiteId { get; set; }

        public int? HotelConfigurationId { get; set; }

    }
}