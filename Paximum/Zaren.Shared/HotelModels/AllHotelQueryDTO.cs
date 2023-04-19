using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Shared.HotelModels
{
    public  class AllHotelQueryDTO
    {
        public string Id { get; set; }
        public int NumberOfTravellers { get; set; } = 1;
        public string CityName { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime ChcekOut { get; set; }
    }
}
