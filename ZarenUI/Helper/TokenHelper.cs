using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Humanizer;
using Microsoft.Extensions.Caching.Distributed;
using Model.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using SanTsgHotelBooking.Application.Models.CommitTransaction.Response;
using SanTsgHotelBooking.Application.Models.GetProductInfoRequest;
using SanTsgHotelBooking.Application.Models.GetProductInfoResponse;
using SanTsgHotelBooking.Application.Models.GetReservationDetail.Response;
using SanTsgHotelBooking.Application.Models.LocationHotelPriceRequest;
using SanTsgHotelBooking.Application.Models.TourVisioLoginResponse;
using SanTsgHotelBooking.Application.Models.CancellationResponse;
using SanTsgHotelBooking.Application.Services.IServices;
using SetReservationInfo.Request;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using ZarenUI.Helper;
using ZarenUI.Models;
using ZarenUI.Services.Models.CreditCart;
using ZarenUI.Services.Models.GetPaymentOption;
using ZarenUI.Services.Models.Payment;
using ZarenUI.Services.Models.Payment.AgencyCredit;
using ZarenUI.Services.Models.Payment.GetPaymentOptionDetail;
using static ZarenUI.Controllers.AccountController;
public class TokenHelper
{

    private readonly ISanTsgTourVisioService _sanTsgTourVisioService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;
    private IDistributedCache _cache;
	private MongoHelper _mongoClient;
	private readonly string _cookie;
	public TokenHelper(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
		_cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
	}

    public TokenHelper(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDistributedCache cache)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _cache = cache;
		_cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
		_mongoClient = new MongoHelper(_httpContextAccessor, _configuration,_cache);
	}
    public TokenHelper(ISanTsgTourVisioService sanTsgTourVisioService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDistributedCache cache)
    {

        _httpContextAccessor = httpContextAccessor;
        _sanTsgTourVisioService = sanTsgTourVisioService;
        _configuration = configuration;
		_cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
		_cache = cache;
		_mongoClient = new MongoHelper(_httpContextAccessor, _configuration, _cache);
	}



    #region Token
    public async Task<string> GetSanTsgTourVisioToken(bool removeCache = false)
    { 
        if (_cookie == null)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddHours(8);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("ZtUser", Guid.NewGuid().ToString(), options);
        }

        if (removeCache)
        { 
            var response = await _sanTsgTourVisioService.AuthLoginTourVisioAsync<TourVisioLoginResponse>();
            if (response != null && response.Header.success)
                _cache.SetString(_cookie, response.Body.token.ToJson());
            return response.Body.token.ToJson();

        }
        else
        { 
            if (_cache.GetString(_cookie) == null)
            {
                var response = await _sanTsgTourVisioService.AuthLoginTourVisioAsync<TourVisioLoginResponse>();
                if (response != null && response.Header.success)
                    _cache.SetString(_cookie, response.Body.token.ToJson());                 
				_mongoClient.Log(response);
				return response.Body.token.ToJson();
            }
            else
            {
                var existingList = JsonConvert.DeserializeObject<string>(_cache.GetString(_cookie));
                return existingList;
            }
        }
    }

    #endregion
    #region Flight
    public OneWayDepartureResponse.GetDepartureResponse GetDepartureAutoComplete(string from, string culture, string serviceType)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + from;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            dynamic dynamicRequest = new
            {
                ProductType = 3,
                Query = from,
                ServiceType = serviceType,
                Culture = culture
            };
            var content = JsonConvert.SerializeObject(dynamicRequest);
			
			var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getdepartureautocomplete", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<OneWayDepartureResponse.GetDepartureResponse>(contents);

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);
 
			if (obj.Header.Success)
                _cache.SetString(encKey, obj.ToJson());
            return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<OneWayDepartureResponse.GetDepartureResponse>(_cache.GetString(encKey));

        }
    }
    public ArrivalAutoComplete.ArrivalAutoCompleteResponse ArrivalAutoComplete(string from, string to, string culture, string serviceType)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + from + "|to:" + to;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<DepartureLocation> dynamicArray = new List<DepartureLocation>();
            dynamicArray.Add(new DepartureLocation()
            {
                Id = to,
                Type = 5
            });
            dynamic dynamicRequest = new
            {
                ProductType = 3,
                Query = from,
                ServiceType = serviceType,
                Culture = culture,
                DepartureLocations = dynamicArray,
            };


            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<ArrivalAutoComplete.ArrivalAutoCompleteResponse>(contents);

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);
			if (obj.Header.Success)
                _cache.SetString(encKey, obj.ToJson());
            return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<ArrivalAutoComplete.ArrivalAutoCompleteResponse>(_cache.GetString(encKey));

        }
    }
    public CheckInResponse.CheckInDatesResponse CheckInDates(string from, string to, string culture, string serviceType)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + from + "|to:" + to; 
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<CheckInRequest.ArrivalLocation> ArrivalLocations = new List<CheckInRequest.ArrivalLocation>();
            ArrivalLocations.Add(new CheckInRequest.ArrivalLocation()
            {
                Id = to,
                Type = 5
            });

            List<CheckInRequest.DepartureLocation> DepartureLocations = new List<CheckInRequest.DepartureLocation>();
            DepartureLocations.Add(new CheckInRequest.DepartureLocation()
            {
                Id = from,
                Type = 5
            });

            CheckInRequest.CheckInDateRequest dynamicRequest = new CheckInRequest.CheckInDateRequest()
            {
                ProductType = 3,
                ServiceType = serviceType,
                ArrivalLocations = ArrivalLocations,
                DepartureLocations = DepartureLocations
            };
            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getcheckindates", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<CheckInResponse.CheckInDatesResponse>(contents);
            if (obj.Body!=null && obj.Body.Dates!=null && obj.Body.Dates.Any())
                _cache.SetString(encKey, obj.ToJson());

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);


			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<CheckInResponse.CheckInDatesResponse>(_cache.GetString(encKey));

        }
    }
    public OneWayRes.OneWayResponse OneWayPriceSearch(string from, string to, string checkIn, int flightBaggageGetOption, List<OneWayReq.Passenger> passenger, string currency, string culture, int FlightClasses = 0, string serviceType = "1")
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + from + "|to:" + to+"|cur:"+ currency; 
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            OneWayReq.OneWayRequest dynamicRequest = new OneWayReq.OneWayRequest();

            List<OneWayReq.ArrivalLocation> ArrivalLocations = new List<OneWayReq.ArrivalLocation>();
            ArrivalLocations.Add(new OneWayReq.ArrivalLocation()
            {
                Id = to,
                Type = 5
            });

            List<OneWayReq.DepartureLocation> DepartureLocations = new List<OneWayReq.DepartureLocation>();
            DepartureLocations.Add(new OneWayReq.DepartureLocation()
            {
                Id = from,
                Type = 2
            });

            dynamicRequest.ProductType = 3;
            dynamicRequest.CheckIn = checkIn;
            dynamicRequest.Culture = culture;
            dynamicRequest.Currency = currency;
            dynamicRequest.ServiceTypes = new List<string> { serviceType };
            dynamicRequest.Passengers = passenger;
            dynamicRequest.ArrivalLocations = ArrivalLocations;
            dynamicRequest.DepartureLocations = DepartureLocations;
            dynamicRequest.AdditionalParameters = new OneWayReq.AdditionalParameters();
            dynamicRequest.AdditionalParameters.GetOptionsParameters = new OneWayReq.GetOptionsParameters();
            dynamicRequest.AdditionalParameters.GetOptionsParameters.FlightBaggageGetOption = flightBaggageGetOption;
            dynamicRequest.AcceptPendingProviders = false;
            dynamicRequest.ForceFlightBundlePackage = false;
            dynamicRequest.DisablePackageOfferTotalPrice = true;
            dynamicRequest.CalculateFlightFees = false;
            dynamicRequest.FlightClasses = new List<int>() { FlightClasses };

            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<OneWayRes.OneWayResponse>(contents);

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);


			if (obj.Header.Success)
                _cache.SetString(encKey, obj.ToJson());
            return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<OneWayRes.OneWayResponse>(_cache.GetString(encKey));

        }
    }
    public RoundTripRes.RoundTripResponse RoundTripPriceSearch(string from, string to, string checkIn, int flightBaggageGetOption, int night, List<RoundTripReq.Passenger> passenger, string currency, string culture, string serviceType = "2", int supportedFlightReponseListTypes = 3)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + from + "|to:" + to; 
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            RoundTripReq.RoundTripRequest dynamicRequest = new RoundTripReq.RoundTripRequest();

            List<RoundTripReq.ArrivalLocation> ArrivalLocations = new List<RoundTripReq.ArrivalLocation>();
            ArrivalLocations.Add(new RoundTripReq.ArrivalLocation()
            {
                Id = to,
                Type = 5,
                Provider = 3
            });

            List<RoundTripReq.DepartureLocation> DepartureLocations = new List<RoundTripReq.DepartureLocation>();
            DepartureLocations.Add(new RoundTripReq.DepartureLocation()
            {
                Id = from,
                Type = 2,
                Provider = 3
            });
            dynamicRequest.Night = night;
            dynamicRequest.ProductType = 3;
            dynamicRequest.CheckIn = checkIn;
            dynamicRequest.SupportedFlightReponseListTypes = new List<int>() { supportedFlightReponseListTypes };
            dynamicRequest.Culture = culture;
            dynamicRequest.Currency = currency;
            dynamicRequest.ServiceTypes = new List<string> { serviceType };
            dynamicRequest.Passengers = passenger;
            dynamicRequest.ArrivalLocations = ArrivalLocations;
            dynamicRequest.DepartureLocations = DepartureLocations;
            dynamicRequest.AdditionalParameters = new RoundTripReq.AdditionalParameters();
            dynamicRequest.AdditionalParameters.GetOptionsParameters = new RoundTripReq.GetOptionsParameters();
            dynamicRequest.AdditionalParameters.GetOptionsParameters.FlightBaggageGetOption = flightBaggageGetOption;
            dynamicRequest.AcceptPendingProviders = false;
            dynamicRequest.ForceFlightBundlePackage = false;
            dynamicRequest.DisablePackageOfferTotalPrice = true;
            dynamicRequest.CalculateFlightFees = false;


            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<RoundTripRes.RoundTripResponse>(contents);
            if (obj.Header.Success)
                _cache.SetString(encKey, obj.ToJson());

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);

			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<RoundTripRes.RoundTripResponse>(_cache.GetString(encKey));

        }
    }

    public MultiCityRes.MultiCityResponse MulticityPriceSearch(string firstFromReturnTo, string firstTosecondFrom, string secondTo, List<string> checkIn, int flightBaggageGetOption, int night, List<MultiCityReq.Passenger> passenger, string currency, string culture, string serviceType = "1", int supportedFlightReponseListTypes = 3)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "Type:" + serviceType + "|c:" + culture + "|from:" + firstFromReturnTo + "|to:" + firstTosecondFrom + "|secFromTo:" + secondTo;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            MultiCityReq.MultiCityRequest dynamicRequest = new MultiCityReq.MultiCityRequest();

            List<MultiCityReq.ArrivalLocation> ArrivalLocations = new List<MultiCityReq.ArrivalLocation>();
            ArrivalLocations.Add(new MultiCityReq.ArrivalLocation()
            {
                Id = firstFromReturnTo,
                Type = 2,

            });
            ArrivalLocations.Add(new MultiCityReq.ArrivalLocation()
            {
                Id = firstTosecondFrom,
                Type = 5,
            });

            List<MultiCityReq.DepartureLocation> DepartureLocations = new List<MultiCityReq.DepartureLocation>();
            DepartureLocations.Add(new MultiCityReq.DepartureLocation()
            {
                Id = secondTo,
                Type = 5,

            });
            DepartureLocations.Add(new MultiCityReq.DepartureLocation()
            {
                Id = firstFromReturnTo,
                Type = 2,

            });
            dynamicRequest.ProductType = 3;
            dynamicRequest.CheckIns = checkIn;
            dynamicRequest.SupportedFlightReponseListTypes = new List<int>() { supportedFlightReponseListTypes };
            dynamicRequest.Culture = culture;
            dynamicRequest.Currency = currency;
            dynamicRequest.ServiceTypes = new List<string> { serviceType };
            dynamicRequest.Passengers = passenger;
            dynamicRequest.ArrivalLocations = ArrivalLocations;
            dynamicRequest.DepartureLocations = DepartureLocations;

            dynamicRequest.AcceptPendingProviders = false;
            dynamicRequest.ForceFlightBundlePackage = false;
            dynamicRequest.DisablePackageOfferTotalPrice = true;
            dynamicRequest.CalculateFlightFees = false;
            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<MultiCityRes.MultiCityResponse>(contents);
            if (obj.Header.Success)
                _cache.SetString(encKey, obj.ToJson());

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);

			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<MultiCityRes.MultiCityResponse>(_cache.GetString(encKey));

        }
    }
    public FlightOffers.GetOffersFlightResponse GetOffersForFlightsById(string offerId, string searchId, string culture, string currency)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "o:" + offerId + "|s:" + searchId + "|cul:" + culture + "|cur:" + currency;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var offers = new List<string>();
            offers.Add(offerId);
            dynamic dynamicRequest = new
            {
                searchId = searchId,
                offerIds = offers,
                productType = 3,
                currency = currency,
                culture = culture,

            };
            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getoffers", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<FlightOffers.GetOffersFlightResponse>(contents);
            if (obj.Header.Success && obj.Body.Offers != null && obj.Body.Offers.Any())
                _cache.SetString(encKey, obj.ToJson());

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);
			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<FlightOffers.GetOffersFlightResponse>(_cache.GetString(encKey));

        }
    }
    #endregion
    #region Hotel
    public async Task<SanTsgHotelBooking.Application.Models.LocationHotelPriceResponse.LocationHotelPriceResponse> LocationHotelPriceSearch(int id, string token, string adults, string children, string rooms, string checkIn, int night, string currency = "TRY", string culture = "tr-TR", string nationality = "TR", int SearchType = 2, bool getOnlyDiscountedPrice = true, bool getOnlyBestOffers = true, int productType = 2, bool checkAllotment = true, bool checkStopSale = true)
    {
        var client = new HttpClient();

        var encKey = "city:" + id + "|a:" + adults + "|c:" + children + "|r:" + rooms + "|In:" + checkIn + "|n:" + night + "|cul:" + culture + "|cur:" + currency;
        if (_cache.GetString(encKey) == null)
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var reqJson = new LocationHotelPriceRequest()
            {
                night = night,
                checkIn = checkIn.ToShortDateTime(),
                currency = currency,
                getOnlyBestOffers = getOnlyBestOffers,
                getOnlyDiscountedPrice = getOnlyDiscountedPrice,
                checkAllotment = checkAllotment,
                checkStopSale = checkStopSale,
                productType = productType,
                culture = culture,

                roomCriteria = new List<RoomCriterion> { new RoomCriterion { adult = adults.ToInt32() } },
                arrivalLocations = new List<ArrivalLocation> {
                new ArrivalLocation {
                    id = id.ToString(),
                    type = SearchType
                }
            }
            };
            var content = JsonConvert.SerializeObject(reqJson);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<SanTsgHotelBooking.Application.Models.LocationHotelPriceResponse.LocationHotelPriceResponse>(contents);

            if (obj.header.success)
                _cache.SetString(encKey, obj.ToJson());
            else if (obj.header != null && obj.header.messages != null && obj.header.messages.FirstOrDefault() != null && obj.header.messages.FirstOrDefault().code == "TokenRequired")
            {
                await GetSanTsgTourVisioToken(true);
                var encKey2 = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString().ClearTextFilterForJson() + _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
                var tokenNew = JsonConvert.DeserializeObject<string>(_cache.GetString(encKey2));
                return await LocationHotelPriceSearch(id, tokenNew, adults, children, rooms, checkIn, night, currency, culture, nationality, SearchType, getOnlyDiscountedPrice, getOnlyBestOffers, productType, checkAllotment, checkStopSale);
            }

			_mongoClient.Log(reqJson);
			_mongoClient.Log(obj);

			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<SanTsgHotelBooking.Application.Models.LocationHotelPriceResponse.LocationHotelPriceResponse>(_cache.GetString(encKey));
        } 
    } 

    public GetProductInfoResponse GetHotelDetailsById(int id, string culture = "tr-TR")
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "h:" + id + "|cul:" + culture;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var dynamicRequest = new GetProductInfoRequest() { product = id.ToString(), culture = culture };

			var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getproductInfo", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<GetProductInfoResponse>(contents);


			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);
			if (obj.header.success)
                _cache.SetString(encKey, obj.ToJson());


			return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<GetProductInfoResponse>(_cache.GetString(encKey));

        }
    }

    public GetOffers.GetOffersResponse GetOffersById(string offerId, string searchId, string hotelId, string culture = "tr-TR", string currency = "TRY")
    {
        var token = GetSanTsgTourVisioToken().Result;
        var encKey = "o:" + offerId + "|s:" + searchId + "|h:" + hotelId + "|cul:" + culture + "|cur:" + currency;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            GetOffers.GetOffersRequest getOffersRequest = new GetOffers.GetOffersRequest()
            {
                searchId = searchId,
                offerId = offerId,
                productType = 2,
                productId = hotelId,
                currency = currency,
                culture = culture,
                getRoomInfo = true,
            };

            var content = JsonConvert.SerializeObject(getOffersRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getoffers", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<GetOffers.GetOffersResponse>(contents);

			_mongoClient.Log(getOffersRequest);
			_mongoClient.Log(obj);


			if (obj.header.success && obj.body.offers != null && obj.body.offers.Any())
                _cache.SetString(encKey, obj.ToJson());
            return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<GetOffers.GetOffersResponse>(_cache.GetString(encKey));

        }
    }

    public GetOfferDetails.GetOfferDetails GetOfferDetailsById(string offerId, string token, string currency = "TRY")
    {
        var encKey = "o:" + offerId + "|cur:" + currency;
        if (_cache.GetString(encKey) == null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var offers = new List<string>();
            offers.Add(offerId);
            dynamic dynamicRequest = new
            {
                offerIds = offers,
                currency = currency,
                getProductInfo = true,
                getRoomInfo = true,
                getRoomContent = true
            };
            var content = JsonConvert.SerializeObject(dynamicRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getofferdetails", byteContent).Result;
            var contents = req.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<GetOfferDetails.GetOfferDetails>(contents);

			_mongoClient.Log(dynamicRequest);
			_mongoClient.Log(obj);

			if (obj.header.success)
                _cache.SetString(encKey, obj.ToJson());
            return obj;
        }
        else
        {
            return JsonConvert.DeserializeObject<GetOfferDetails.GetOfferDetails>(_cache.GetString(encKey));

        }
    }
    #endregion
    #region Booking

    public GetReservationDetailResponse GetReservationDetail(string ReservationNumber)
    {

        var token = GetSanTsgTourVisioToken().Result;

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            ReservationNumber = ReservationNumber
        };

        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/getreservationdetail", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<GetReservationDetailResponse>(contents);

		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);


		if (obj.header.success)
        {

        }
        return obj;

    }
    public GetReservationDetailResponse SetReservationInfo(string reservationId, string currency = "TRY", string culture = "tr-TR")
    {

        var token = GetSanTsgTourVisioToken().Result;

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        SetReservationInfo.Request.SetReservationInfoRequest SetReservationInfoRequest = new SetReservationInfo.Request.SetReservationInfoRequest();
        SetReservationInfoRequest.travellers = new List<SetReservationInfo.Request.Traveller>();
        SetReservationInfoRequest.transactionId = reservationId;

        var bookingRepo = new BookingReservationsRepository(_configuration);
        var bookingReservation = bookingRepo.GetByTransactionId(reservationId).FirstOrDefault();
        if (bookingReservation != null)
        {
            SetReservationInfoRequest.reservationNote = bookingReservation.Note;
        }
        BookingTravellersRepository BookingTravellersRepository = new BookingTravellersRepository(_configuration);

        var travellers = BookingTravellersRepository.GetByReservationNumber(reservationId);
        var travellerId = 1;
        foreach (var item in travellers)
        {
            SetReservationInfoRequest.travellers.Add(new SetReservationInfo.Request.Traveller()
            {
                birthDate = item.BirthDate.ToDateTime(),
                surname = item.LastName,
                name = item.FirstName,
                identityNumber = item.GovernmentId,
                isLeader = item.IsFirstContact.ToBool(),
                travellerId = travellerId.ToString(),
                passengerType = 1,
                type = 1,
                title = item.Gender.ToInt32(),
            });
            travellerId++;
        }

        var content = JsonConvert.SerializeObject(SetReservationInfoRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/setreservationinfo", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<GetReservationDetailResponse>(contents);

		_mongoClient.Log(SetReservationInfoRequest);
		_mongoClient.Log(obj);

		if (obj.header.success)
        {
            var commitResponse = CommitTransaction(reservationId);
            if (commitResponse.header.success)
            {
                if (bookingReservation != null && bookingReservation.Id > 0)
				{ 
					bookingReservation.ReservationNumber = commitResponse.body.reservationNumber;
                    bookingReservation.Guid = commitResponse.body.encryptedReservationNumber;
                    bookingReservation.ReservationStatus = obj.body.reservationData.reservationInfo.reservationStatus;
					bookingReservation.PaymentStatus = obj.body.reservationData.reservationInfo.paymentStatus;
					bookingReservation.ConfirmationStatus = obj.body.reservationData.reservationInfo.confirmationStatus;
                    bookingReservation.Status = (int)TransactionStatus.Committed; 
					bookingRepo.Update(bookingReservation);
                }
            }
        }
        return obj;

    }
    public Reservation.Root BeginTransaction(string offerId, string userId, string currency = "TRY", string culture = "tr-TR")
    {
        var token = GetSanTsgTourVisioToken().Result;

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var offers = new List<string>();
        offers.Add(offerId);
        dynamic dynamicRequest = new
        {
            offerIds = offers,
            currency = currency,
            culture = culture
        };

        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/begintransaction", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<Reservation.Root>(contents);
        if (obj.Header.Success)
        {
            
            BookingReservationsRepository BookingReservationsRepository = new BookingReservationsRepository(_configuration);
            BookingReservationsRepository.Insert(new Model.Concrete.BookingReservations()
            {
                OfferId = offerId,
                BeginDate = DateTime.Now,
                CookieId = _cookie,
                CreatedDate = DateTime.Now,
                Culture = culture,
                Currency = currency,
                HasPaid = 0,
                ExpireDate = obj.Body?.ExpiresOn,
                TransactionId = obj.Body?.TransactionId, 
                BookingNumber = obj.Body?.ReservationData?.ReservationInfo?.BookingNumber,
				ProductType = 2,
                Note = "",
                EndDate = DateTime.Now,
                Status = obj.Body.Status,
                UserId = userId,
                JsonData = obj.Body?.ReservationData?.Services?.ToJson(),
                OnBasket = true,
                Guid = DateTime.Now.Ticks.ToString(),
                UserIp = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                UserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"],
                ConfirmationStatus= (int)ConfirmationStatus.New,
                PaymentStatus= (int)PaymentStatus.New,
                ReservationStatus=(int)ReservationStatus.New
            });
        }

		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return obj;

    }

    public CommitTransactionResponse CommitTransaction(string transactionId)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {

            transactionId = transactionId
        };

        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/committransaction", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<CommitTransactionResponse>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);
		return obj;
    }

    public AspNetUsers GetUserByToken()
    {
        try
        { 
            if (_cookie != null)
                return new AspNetUsersRepository(_configuration).GetUserByToken(_cookie);
            else
                return null;
        }
        catch
        {
            return null;
        }
    }
    public List<BookingReservations> GetBasket()
    {
        try
        {
            var bookingReservationsRepository = new BookingReservationsRepository(_configuration);
     
            if (_cookie != null)
                return bookingReservationsRepository.GetByCookie(_cookie);
            else
                return null;
        }
        catch
        {
            return null;
        }
    }



    #endregion
    #region Payment
    public GetPaymentOptionResponse GetPaymentOptions(string transactionId)
    {
        var token = GetSanTsgTourVisioToken().Result;

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            transactionId = transactionId

        };
        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/agencyservice/getpaymentoptions", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<GetPaymentOptionResponse>(contents);

		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return obj;

    }

    public GetPaymentOptionDetailResponse GetPaymentOptionDetail(string transactionId, string PaymentOption = "3")
    {
        var token = GetSanTsgTourVisioToken().Result;

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            transactionId = transactionId,
            PaymentOption = PaymentOption

        };
        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/agencyservice/getpaymentoptiondetail", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<GetPaymentOptionDetailResponse>(contents);

		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return obj;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="transactionId"></param>
    /// <param name="CardInfo"></param>
    /// <param name="PaymentOption">3 Credit Card</param>
    /// <param name="PaymentProvider">1008 Garanti</param>
    /// <returns></returns>
    public string BeginPaymentTransaction(string transactionId, CardInfo CardInfo)
    {
        int PaymentOption = 0;
        string PaymentProvider = "";
        var token = GetSanTsgTourVisioToken().Result;

        var paymentOptions = GetPaymentOptions(transactionId);
        if (paymentOptions != null && paymentOptions.Body != null && paymentOptions.Body.Options != null && paymentOptions.Body.Options.Any())
        {
            PaymentOption = paymentOptions.Body.Options.FirstOrDefault();
            foreach (var item in paymentOptions.Body.Options)
            {
                var response = GetPaymentOptionDetail(transactionId, item.ToString());
            }
        }

        CardInfo.CardNo = CardInfo.CardNo.Replace(" ", "").Replace("-", "");
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        CreditCartRequest dynamicRequest = new CreditCartRequest()
        {
            TransactionId = transactionId,
            PaymentOption = PaymentOption,
            PaymentTypeId = PaymentProvider,
            Installment = 1,
            SuccessUrl = "https://localhost:3001/thankyou/" + transactionId + "?result=success",
            ErrorUrl = "https://localhost:3001/thankyou/" + transactionId + "?result=error",
            CardInfo = CardInfo
        };
        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/paymentservice/beginpaymenttransaction", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
		

			 var obj = JsonConvert.DeserializeObject<BeginPayment.Root>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return contents;

    }
    public string GetPaymentTypes(string transactionId, string culture)
    {
        var token = GetSanTsgTourVisioToken().Result; 
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            transactionId = transactionId,
            culture = culture 
        };
        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/agencyservice/getpaymenttypes", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;

		var obj = JsonConvert.DeserializeObject<BeginPayment.Root>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return contents;

    }


	public GetTransactionStatus.Root GetTransactionStatus(string transactionId, string culture)
	{
		var token = GetSanTsgTourVisioToken().Result;

		var client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		dynamic dynamicRequest = new
		{
			transactionId = transactionId

		};
		var content = JsonConvert.SerializeObject(dynamicRequest);
		var buffer = System.Text.Encoding.UTF8.GetBytes(content);
		var byteContent = new ByteArrayContent(buffer);
		var req = client.PostAsync("http://service.stage.paximum.com/v2/api/TransactionService/GetTransactionStatus", byteContent).Result;
		var contents = req.Content.ReadAsStringAsync().Result;


		var objRequest = JsonConvert.DeserializeObject<GetTransactionStatus.Request>(content);        	
		var obj = JsonConvert.DeserializeObject<GetTransactionStatus.Root>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj); 
		return obj; 
	} 

	public AgencyCreditBeginPaymentTransactionResponse AgencyCredit(string transactionId, string currency = "TRY", string culture = "tr-TR")
    {
        var token = GetSanTsgTourVisioToken().Result;
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            currency = currency,
            culture = culture,
            transactionId = transactionId,
            paymentOption = 2,
            successUrl = "https://localhost:3001/thankyou/" + transactionId + "?result=success",
            errorUrl = "https://localhost:3001/thankyou/" + transactionId + "?result=error",
            termsAndConditionsUrl = "http://localhost:3001/Content/RenderContent/TermsAndConditions",
            non3DPayment = false
        };

        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/paymentservice/beginpaymenttransaction", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result; 


		var objRequest = JsonConvert.DeserializeObject<GetTransactionStatus.Request>(content);
		var obj = JsonConvert.DeserializeObject<AgencyCreditBeginPaymentTransactionResponse>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);

		return obj;
    }

    public CheckPaymentResponse CheckPayment(string paymentTransactionId)
    {
        var token = GetSanTsgTourVisioToken().Result;
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        dynamic dynamicRequest = new
        {
            paymentTransactionId = paymentTransactionId
        };

        var content = JsonConvert.SerializeObject(dynamicRequest);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/PaymentService/CheckPayment", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<CheckPaymentResponse>(contents);
		_mongoClient.Log(dynamicRequest);
		_mongoClient.Log(obj);
		return obj;
    }
    #endregion

    #region Cancellation
    public CancellationResponse GetCancellationPenalty(string reservationNumber, string token)
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var _cancellationreq = new SanTsgHotelBooking.Application.Models.CancellationRequest.CancellationRequest()
        {
            reservationNumber = reservationNumber
        };
        var content = JsonConvert.SerializeObject(_cancellationreq);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        var req = client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/getcancellationpenalty", byteContent).Result;
        var contents = req.Content.ReadAsStringAsync().Result;
        var obj = JsonConvert.DeserializeObject<CancellationResponse>(contents);

        return obj;
    }
    #endregion


}

