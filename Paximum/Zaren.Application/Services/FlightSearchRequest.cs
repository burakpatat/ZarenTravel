namespace Zaren.Application.Services
{
    internal class FlightSearchRequest
    {
        public int ProductType { get; internal set; }
        public string ServiceType { get; internal set; }
        public string Culture { get; internal set; }
        public string Query { get; internal set; }
    }
}