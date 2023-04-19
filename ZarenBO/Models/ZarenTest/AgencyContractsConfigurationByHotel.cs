using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyContractsConfigurationByHotel", Schema = "dbo")]
    public partial class AgencyContractsConfigurationByHotel
    {
        public int? MicroSiteId { get; set; }

        public int? HotelConfigurationId { get; set; }

    }
}