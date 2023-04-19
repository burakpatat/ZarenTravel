using System;

namespace Model.FlightModels.Concrete
{
    public class AirPortTax
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int CurrenciesId { get; set; }
        public Offers Offers { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
