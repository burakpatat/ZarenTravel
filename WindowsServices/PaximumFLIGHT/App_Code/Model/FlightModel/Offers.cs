using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class Offers
    {
        public int Id { get; set; }
        public int SegmentNumber { get; set; }
        public bool IsPackageOffer { get; set; }
        public bool HasBrand { get; set; }
        public int Route { get; set; }
        public string ExpresOn { get; set; }
        public string OfferId { get; set; }
        public int Provider { get; set; }
        public double SingleAdultPrice { get; set; }
        public bool ReservableInfo { get; set; }
        public int PriceId { get; set; }
        public  Price Price { get; set; }
        public int AirPortTaxId { get; set; }
        public AirPortTax AirPortTax { get; set; }
        public int SingleAdultPriceCurrencyId { get; set; }
        public int ServiceFeesId { get; set; }
        public ServiceFees ServiceFees { get; set; }
        public int SeatInfosId { get; set; }
        public SeatInfos SeatInfos { get; set; }
        public int FlightsId { get; set; }
        public Flights Flights { get; set; }
        public int FlightFeesId { get; set; }
        public FlightFees FlightFees { get; set; }
        public int FlightProvidersId { get; set; }
        public FlightProviders FlightProviders { get; set; }
        public ICollection<PriceBreakDowns> PriceBreakDowns { get; set; }
        public ICollection<FlightClasses> FlightClasses { get; set; }
        public ICollection<BaggageInformations> BaggageInformations { get; set; }
        public ICollection<Services> Services { get; set; }
        public ICollection<GroupKeys> GroupKeys { get; set; }
        public int FlightBrandsId { get; set; }
        public FlightBrands FlightBrands { get; set; }

        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
