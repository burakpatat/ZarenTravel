using System;

namespace Model.FlightModels.Concrete
{
    public class PriceBreakDowns
    {
        public int Id { get; set; }
        public int PassengerTypeId { get; set; }
        public int PassengerCount { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public double AirportTaxAmount { get; set; }
        public int AirportTaxCurrencyId { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
