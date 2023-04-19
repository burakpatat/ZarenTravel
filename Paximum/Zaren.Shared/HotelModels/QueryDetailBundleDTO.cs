using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Shared.HotelModels
{
    public class QueryDetailBundleDTO
    {
        List<HotelDetailDTO> HotelDetailDTO = new List<HotelDetailDTO>();
        HotelQueryDTO HotelQueryDTO { get; set; }
    }
}
