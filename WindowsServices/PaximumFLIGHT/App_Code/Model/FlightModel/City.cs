using Model.FlightModels.Concrete;
using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
        public FlightItems Items { get; set; }

    }
}
