using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Domain
{
    public class CityObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int HotelCount { get; set; }
        public DateTime checkIn { get; set; }
        public int NumberOfTravellers { get; set; } = 1;


    }
}
