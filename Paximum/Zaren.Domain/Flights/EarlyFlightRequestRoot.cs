using Zaren.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Domain.Flights
{
    public class EarlyFlightRequestRoot
    {
        public int ProductType { get; set; } = 3;
        public string Query { get; set; } = "IST";
        public List<DepartureLocation> DepartureLocations { get; set; }
        public string Culture { get; set; } = "tr-TR";
        public string ServiceType { get; set; } = "1"; //1: TEK YÖN 2: GİDİŞ DÖNÜŞ 3: MULTICITY
    }
    public class DepartureLocation
    {
        public int type { get; set; }
        public string id { get; set; }
    }
}
