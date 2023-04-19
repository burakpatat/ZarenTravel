using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class Currency
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public string Number { get; set; }

        public bool  IsActive { get; set; }

        public int TableOrder { get; set; }
    }
}