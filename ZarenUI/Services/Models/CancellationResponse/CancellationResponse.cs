namespace SanTsgHotelBooking.Application.Models.CancellationResponse
{
    public class CancellationResponse
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }
    public class Body
    {
        public List<CancelPenalty> cancelPenalties { get; set; }
    }

    public class CancelPenalty
    {
        public Reason reason { get; set; }
        public List<Service> services { get; set; }
        public Price price { get; set; }
        public bool isCancelable { get; set; }
    }

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public List<Message> messages { get; set; }
    }

    public class MainServiceFee
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class Penalty
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class Price
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PriceDetail
    {
        public TotalSalePrice totalSalePrice { get; set; }
        public Penalty penalty { get; set; }
        public MainServiceFee mainServiceFee { get; set; }
    }

    public class Reason
    {
        public string comment { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Service
    {
        public int provider { get; set; }
        public string id { get; set; }
        public string code { get; set; }
        public int productType { get; set; }
        public string name { get; set; }
        public Price price { get; set; }
        public bool isCancelable { get; set; }
        public List<object> relatedServices { get; set; }
        public PriceDetail priceDetail { get; set; }
    }

    public class TotalSalePrice
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }
}
