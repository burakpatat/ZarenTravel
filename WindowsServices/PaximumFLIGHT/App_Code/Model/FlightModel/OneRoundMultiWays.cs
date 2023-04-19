using System;

namespace Model.FlightModels.Concrete
{
    public class OneRoundMultiWays
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int TotalPrice { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int PassengerTypesId { get; set; }
        public PassengerTypes PassengerTypes { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
