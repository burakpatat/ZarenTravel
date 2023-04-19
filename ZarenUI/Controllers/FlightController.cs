using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Model.Concrete;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using ZarenUI;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private TokenHelper _tokenHelper;
    private readonly string _strConnString; 
    private IDistributedCache _cache;
    private IConfiguration _configuration; 
    private readonly IHttpContextAccessor _httpContextAccessor;
    public FlightController(IConfiguration configuration, IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _cache = cache;
        _strConnString = configuration.GetConnectionString("ZarenTravel");
        _httpContextAccessor = httpContextAccessor;
        _tokenHelper = new TokenHelper(_httpContextAccessor, _configuration, _cache); 
    } 

    [HttpGet("~/DepartureAutoComplete")]
    public ActionResult<string> DepartureAutoComplete(string from, string culture,string serviceType)
    {
      return  _tokenHelper.GetDepartureAutoComplete(from, culture, serviceType).ToJson();
    }


    [HttpGet("~/ArrivalAutoComplete")]
    public ActionResult<string> ArrivalAutoComplete(string from, string to, string culture, string serviceType)
    {
        return _tokenHelper.ArrivalAutoComplete(from, to, culture, serviceType).ToJson();
    }

    [HttpGet("~/CheckInDates")]
    public ActionResult<string> CheckInDates(string queryFrom, string queryTo, string culture, string serviceType)
    {
        return _tokenHelper.CheckInDates(queryFrom, queryTo, culture, serviceType).ToJson();
    }

    [HttpGet("~/OneWayPriceSearch")]
    public ActionResult<string> OneWayPriceSearch(string queryFrom, string queryTo,string checkin, string culture,string currency,int flightClass, string serviceType,int passenger)
    {
        // string queryFrom, string queryTo, string checkIn, int flightBaggageGetOption, List< OneWayReq.Passenger > passenger, string currency, string culture, int FlightClasses = 0, string serviceType = "1"
        int flightBaggageGetOption = 0;
        List<OneWayReq.Passenger> passengerList = new List<OneWayReq.Passenger>(); 
            passengerList.Add(new OneWayReq.Passenger() {Type=1,Count=passenger});    
        return _tokenHelper.OneWayPriceSearch(queryFrom, queryTo, checkin, flightBaggageGetOption, passengerList, currency,culture, flightClass, serviceType).ToJson();
    }

    [HttpGet("~/RoundtripPriceSearch")]
    public ActionResult<string> RoundtripPriceSearch(string queryFrom, string queryTo, string checkin,int night, string culture, string currency, string serviceType, int passenger)
    {
        // string queryFrom, string queryTo, string checkIn, int flightBaggageGetOption, List< OneWayReq.Passenger > passenger, string currency, string culture, int FlightClasses = 0, string serviceType = "1"
        int flightBaggageGetOption = 0;
        List<RoundTripReq.Passenger> passengerList = new List<RoundTripReq.Passenger>();
        passengerList.Add(new RoundTripReq.Passenger() { Type = 1, Count = passenger });
        return _tokenHelper.RoundTripPriceSearch(queryFrom, queryTo, checkin, flightBaggageGetOption, night, passengerList, currency, culture, serviceType).ToJson();
    }

    [HttpGet("~/MulticityPriceSearch")]
    public ActionResult<string> MulticityPriceSearch(string firstFromReturnTo, string firstTosecondFrom, string secondTo, string checkin, string checkOut, string checkin2, string checkOut2, int night, string culture, string currency,  int passenger)
    {
        int flightBaggageGetOption = 0;
        List<MultiCityReq.Passenger> passengerList = new List<MultiCityReq.Passenger>();
        passengerList.Add(new MultiCityReq.Passenger() { Type = 1, Count = passenger });

        List<string> list = new List<string>();
        list.Add(checkin);
        list.Add(checkOut);
        list.Add(checkin2);
        list.Add(checkOut2);
        return _tokenHelper.MulticityPriceSearch(firstFromReturnTo, firstTosecondFrom, secondTo, list, flightBaggageGetOption, night, passengerList, currency, culture).ToJson();
    }


    [HttpGet("~/FlightsOffers")]
    public ActionResult<string> GetOffersForFlightsById(string offerId, string searchId, string culture = "tr-TR", string currency = "TRY")
    {
        return _tokenHelper.GetOffersForFlightsById(offerId, searchId, culture, currency).ToJson();
    }
}
