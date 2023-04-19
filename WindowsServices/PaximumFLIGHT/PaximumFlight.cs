using ApiCrawler.Authentication;
using ApiCrawler.Paximum.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Paximum.Enums;
using Model.Concrete;
using ApiCrawler.Paximum.App_Code.Paximum.FlightRequest;
using ApiCrawler.Paximum.App_Code.Paximum.FlightResponse.PriceSearchResponse;
using ApiCrawler.Paximum.App_Code.Paximum.FlightRequest.PriceSearchsRequest;
using ApiCrawler.Paximum.App_Code.Paximum.FlightResponse;

namespace Api.Paximum
{
    public partial class PaximumFlight : ServiceBase
    {
        IDbConnection connection;
        public PaximumFlight()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Timer timer = new Timer();
            timer.Interval = ConfigurationManager.AppSettings["Timer"].ToInt32() * 1000;
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
            // GetUserTimelineTweets();
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {

        }
        protected override void OnStop()
        {
        }
        internal void TestStartupAndStop()
        {

            this.OnTimer(null, null);
            RunYourCode();
            //RunYourCodePaximumFlight();
            this.OnStop();
        }
        public void RunYourCodePaximumFlight()
        {

            var bodyData = new LoginResponse();
            try
            {
                bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
                if (bodyData == null || (bodyData != null && bodyData.Body == null) || (bodyData != null && bodyData.Body != null && bodyData.Body.ExpiresOn < DateTime.Now))
                {
                    new LoginService().Login();
                    bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
                }
            }
            catch
            {
                new LoginService().Login();
                bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
            }


        }
        public void RunYourCode()
        {
            var autoCompleteRepository = new AutoCompletesRepository();
            var currencyRepository = new CurrencyRepository();
            var datesRepository = new DatesRepository();

            #region LoginProcess
            var bodyData = new LoginResponse();
            try
            {
                bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
                if (bodyData == null || (bodyData != null && bodyData.Body == null) || (bodyData != null && bodyData.Body != null && bodyData.Body.ExpiresOn < DateTime.Now))
                {
                    new LoginService().Login();
                    bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
                }
            }
            catch
            {
                new LoginService().Login();
                bodyData = JsonConvert.DeserializeObject<ApiCrawler.Authentication.LoginResponse>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json"));
            }
            #endregion

            var cultures = JsonConvert.DeserializeObject<List<Cultures>>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\cultures.json"));
            var productTypes = JsonConvert.DeserializeObject<Types>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\Types\\ProductTypes.json"));

            foreach (var itemType in productTypes.TypeItems)
            {
                foreach (var itemCulture in cultures)
                {
                    if (itemType.Value == 3)
                    {
                        var pricesearchFlightsRepositoryOneWay = new FlightsRepository();
                        var GetArrivalAutocomplete = JsonConvert.DeserializeObject<GetDepartureAutoCompleteRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\GetArrivalAutocomplete.json"));
                        GetArrivalAutocomplete.ProductType = 3;
                        GetArrivalAutocomplete.Culture = itemCulture.CountryCode;
                        var list = new PossibleQueryRepository().GetAll().Where(a => a.Query == "ant");
                        var client = new HttpClient();
                        FlightProvidersRepository providersRepository = new FlightProvidersRepository();
                        foreach (var possibleQuery in list)
                        {

                            #region FlightAutcomplete Insert
                            GetArrivalAutocomplete.Query = possibleQuery.Query;
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var content = JsonConvert.SerializeObject(GetArrivalAutocomplete);
                            var buffer = Encoding.UTF8.GetBytes(content);
                            var byteContent = new ByteArrayContent(buffer);
                            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getdepartureautocomplete", byteContent);
                            var contents = req.Result.Content.ReadAsStringAsync().Result;

                            GetArrivalAutoCompleteResponse.Root AutoCompleteResponse = JsonConvert.DeserializeObject<GetArrivalAutoCompleteResponse.Root>(contents);

                            foreach (var item in AutoCompleteResponse.Body.Items)
                            {
                                foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                {
                                    var controlItem = autoCompleteRepository.GetByName(item?.Airport?.Name).Where(a => a.Name == item.Airport?.Name).FirstOrDefault();
                                    if (controlItem == null)
                                    {
                                        autoCompleteRepository.Insert(new AutoCompletes()
                                        {
                                            ApiId = (int)ApiType.Paximum,
                                            SystemId = item.Airport?.Id,
                                            Name = item.Airport?.Name,
                                            SystemType = item.Type.ToString(),
                                            Type = (int)AutoCompleteTypes.Airport,
                                            LanguageId = itemCountry.DefaultLanguageId
                                        });
                                    }
                                    else
                                    if (controlItem != null)
                                    {
                                        autoCompleteRepository.Update(new AutoCompletes()
                                        {
                                            Id = controlItem.Id,
                                            ApiId = (int)ApiType.Paximum,
                                            SystemId = item.Airport?.Id,
                                            Name = item.Airport?.Name,
                                            SystemType = item.Type.ToString(),
                                            Type = (int)AutoCompleteTypes.Airport,
                                            LanguageId = itemCountry.DefaultLanguageId
                                        });
                                    }
                                }
                            }
                            #endregion

                            #region FlightGetcheckindates Insert
                            var CheckInDatesRequest = JsonConvert.DeserializeObject<ApiCrawler.Paximum.FlightRequest.CheckInDatesRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\CheckInDates.json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var contentCheckIn = JsonConvert.SerializeObject(CheckInDatesRequest);
                            var bufferCheckIn = Encoding.UTF8.GetBytes(contentCheckIn);
                            var byteContentCheckIn = new ByteArrayContent(bufferCheckIn);
                            var reqCheckIn = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getcheckindates", byteContentCheckIn);
                            var contentsCheckIn = reqCheckIn.Result.Content.ReadAsStringAsync().Result;
                            ApiCrawler.Paximum.FlightResponse.CheckInDatesResponse.Root CheckInDatesResponse = JsonConvert.DeserializeObject<ApiCrawler.Paximum.FlightResponse.CheckInDatesResponse.Root>(contentsCheckIn);
                            foreach (var item in CheckInDatesResponse.Body.Dates)
                            {
                                foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                {
                                    datesRepository.Insert(new Dates
                                    {
                                        Date = item,
                                        ArrivalCode = "AYT",
                                        ArrivalType = 5,
                                        DepartureCode = "IST",
                                        DepartureType = 5,
                                        ApiId = (int)ApiType.Paximum,
                                        LanguageId = itemCountry.DefaultLanguageId,
                                    });
                                }
                            }
                            #endregion

                            #region FlightPriceSearch OneWay Insert

                            var GetPriceOneWaySearch = JsonConvert.DeserializeObject<GetPriceSearchOneWayRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\PriceSearchOneWayFlight.json"));

                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var PriceSearchOneway = JsonConvert.SerializeObject(GetPriceOneWaySearch);
                            var bufferPriceSearchOneway = Encoding.UTF8.GetBytes(PriceSearchOneway);
                            var byteContentPriceSearchOneway = new ByteArrayContent(bufferPriceSearchOneway);
                            var reqPriceSearch = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContentPriceSearchOneway);
                            var contentsPriceSearchOneway = reqPriceSearch.Result.Content.ReadAsStringAsync().Result;
                            GetPriceSearchOneWayResponse PriceSearchOneWayResponse = JsonConvert.DeserializeObject<GetPriceSearchOneWayResponse>
(contentsPriceSearchOneway);
                            foreach (var item in PriceSearchOneWayResponse.Body.Flights)
                            {
                                if (item != null)
                                {
                                    foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                    {

                                        #region Flight Insert
                                        var flightInsertedId = pricesearchFlightsRepositoryOneWay.Insert(new Flights()
                                        {
                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                            Provider = item.Provider,
                                            SystemId = item.Id,
                                            ApiId = 1,
                                            CreatedBy = 1,
                                            CreatedDate = DateTime.Now,
                                            UpdatedBy = 1,
                                            UpdatedDate = DateTime.Now,
                                            ProductType = 3,
                                            ServiceTypes = "1"
                                        }).ToInt32();
                                        #endregion

                                        #region GroupKeyInsert

                                        if (item.GroupKey != null && item.GroupKey.Any())
                                        {
                                            using (var keyRepo = new GroupKeysRepository())
                                            {
                                                foreach (var itemGroupKeys in item.GroupKey)
                                                {
                                                    var controlGroupKeyExist = keyRepo.GetByName(itemGroupKeys).FirstOrDefault();
                                                    if (controlGroupKeyExist == null)
                                                    {

                                                        int controlGroupKeyExistId = keyRepo.Insert(new GroupKeys()
                                                        {
                                                            FlightsId = flightInsertedId,
                                                            Name = itemGroupKeys,
                                                            SystemId = item.Id,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            FlightOffersId = 0
                                                        }).ToInt32();
                                                    }
                                                    else
                                                    {
                                                        keyRepo.Update(new GroupKeys()
                                                        {
                                                            Id = controlGroupKeyExist.Id,
                                                            FlightsId = flightInsertedId,
                                                            Name = itemGroupKeys,
                                                            SystemId = item.Id,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = controlGroupKeyExist.CreatedDate,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now

                                                        });
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                        List<BaggageInformations> baggageList = new List<BaggageInformations>();
                                        int providerId = 0;
                                        #region ItemsInsert
                                        if (item.Items != null && item.Items.Any())
                                        {
                                            using (var keyItemsRepo = new FlightItemsRepository())
                                            {

                                                foreach (var itemItems in item.Items)
                                                {
                                                    int classId = 0;
                                                    int airportDepartureId = 0;
                                                    int airportArrivalId = 0;
                                                    int airlineId = 0;
                                                    int marketingairlineId = 0;
                                                    int segmentId = 0;


                                                    #region AirportsInsert
                                                    using (AirPortsRepository airportRepoId = new AirPortsRepository())
                                                    {
                                                        var controlairportDeparture = airportRepoId.GetByName(itemItems.Departure.Airport.Name).FirstOrDefault();
                                                        var controlairportArrival = airportRepoId.GetByName(itemItems.Arrival.Airport.Name).FirstOrDefault();

                                                        if (controlairportDeparture == null)
                                                        {
                                                            AirPorts airPortDeparture = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = itemItems.Departure.Airport.Name,
                                                                SystemId = itemItems.Departure.Airport.Id,
                                                                Code = itemItems.Departure.Airport.Code,
                                                                Latitude = itemItems.Departure.GeoLocation.Latitude,
                                                                Longitude = itemItems.Departure.GeoLocation.Longitude

                                                            };
                                                            int airportDepartureControlId = airportRepoId.Insert(airPortDeparture).ToInt32();
                                                            airportDepartureId = airportDepartureControlId;
                                                        }
                                                        else
                                                        {
                                                            airportDepartureId = controlairportDeparture.Id;
                                                        }
                                                        if (controlairportArrival == null)
                                                        {
                                                            AirPorts airPortArrival = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = itemItems.Arrival.Airport.Name,
                                                                SystemId = itemItems.Arrival.Airport.Id,
                                                                Code = itemItems.Arrival.Airport.Code,
                                                                Latitude = itemItems.Arrival.GeoLocation.Latitude,
                                                                Longitude = itemItems.Arrival.GeoLocation.Longitude

                                                            };
                                                            int airportArrivalControlId = airportRepoId.Insert(airPortArrival).ToInt32();
                                                            airportArrivalId = airportArrivalControlId;
                                                        }
                                                        else
                                                        {
                                                            airportArrivalId = controlairportArrival.Id;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightProviderInsert
                                                    using (FlightProvidersRepository flightProviderRepository = new FlightProvidersRepository())
                                                    {
                                                        var providerControl = flightProviderRepository.GetByDisplayName(itemItems.FlightProvider.DisplayName).FirstOrDefault();
                                                        if (providerControl == null)
                                                        {
                                                            var flightProviderId = flightProviderRepository.Insert(new FlightProviders
                                                            {
                                                                SystemId = itemItems.FlightProvider.Id,
                                                                DisplayName = itemItems.FlightProvider.DisplayName,
                                                                Name = itemItems.FlightProvider.Name,
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                UpdatedBy = 1,
                                                                UpdatedDate = DateTime.Now,
                                                            }).ToInt32();
                                                            providerId = flightProviderId;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightItemsInsert
                                                    var controlItemsExistId = keyItemsRepo.Insert(new FlightItems()
                                                    {
                                                        SegmentNumber = itemItems.SegmentNumber,
                                                        FlightNo = itemItems.FlightNo,
                                                        PnlName = itemItems.PnlName,
                                                        FlightDate = itemItems.FlightDate,
                                                        Duration = itemItems.Duration,
                                                        DayChange = itemItems.DayChange,
                                                        Route = itemItems.Route,
                                                        StopCount = itemItems.StopCount,
                                                        FlightType = itemItems.FlightType,
                                                        AirLinesId = itemItems.Airline.Id,
                                                        MarketingAirlines = itemItems.MarketingAirline.Id,
                                                        FlightClassesSystemId = itemItems.FlightClass.Id,

                                                        FlightsId = flightInsertedId,
                                                        FlightClassesId = classId,
                                                        FlightProviderId = providerId,
                                                        ProductType = 3,
                                                        ServiceTypes = "1",

                                                        SystemId = item.Id,
                                                        ApiId = 1,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now

                                                    }).ToInt32();
                                                    #endregion

                                                    #region DepartureInsert
                                                    DeparturesRepository departureRepository = new DeparturesRepository();

                                                    Departures departure = new Departures()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,

                                                        AirPortsId = airportDepartureId,
                                                        CountryId = itemCountry.Id,
                                                        Date = itemItems.Departure.Date,
                                                        Latitude = itemItems.Departure.GeoLocation.Latitude,
                                                        Longitude = itemItems.Departure.GeoLocation.Longitude,
                                                        CitySystemId = itemItems.Departure.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int departureId = departureRepository.Insert(departure).ToInt32();

                                                    #endregion

                                                    #region ArrivalInsert
                                                    ArrivalsRepositoy arrivalsRepository = new ArrivalsRepositoy();

                                                    Arrivals arrival = new Arrivals()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        AirPortsId = airportArrivalId,
                                                        CountryId = itemCountry.Id,
                                                        Date = itemItems.Arrival.Date,
                                                        Latitude = itemItems.Arrival.GeoLocation.Latitude,
                                                        Longitude = itemItems.Arrival.GeoLocation.Longitude,
                                                        CitySystemId = itemItems.Arrival.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int arrivalId = arrivalsRepository.Insert(arrival).ToInt32();

                                                    #endregion

                                                    #region AirlineInsert
                                                    var airLinesRepository = new AirLinesRepository();
                                                    var controlairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(itemItems.Airline.InternationalCode.ToString(), false).FirstOrDefault();

                                                    if (controlairlines == null)
                                                    {
                                                        var airline = new AirLines()
                                                        {
                                                            InterNationalCode = itemItems.Airline.InternationalCode,
                                                            Logo = itemItems.Airline.Logo,
                                                            LogoFull = itemItems.Airline.LogoFull,
                                                            Name = itemItems.Airline.Name,
                                                            SystemId = itemItems.Airline.Id,
                                                            Thumbnail = itemItems.Airline.Thumbnail,
                                                            ThumbnailFull = itemItems.Airline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = false,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int airlinenewInsertId = airLinesRepository.Insert(airline).ToInt32();

                                                        airlineId = airlinenewInsertId;
                                                    }
                                                    else
                                                    {
                                                        airlineId = controlairlines.Id;
                                                    }
                                                    var controlmarketingairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(itemItems.Airline.InternationalCode, true).FirstOrDefault();
                                                    if (controlmarketingairlines == null)
                                                    {
                                                        var marketingairline = new AirLines
                                                        {
                                                            InterNationalCode = itemItems.MarketingAirline.InternationalCode,
                                                            Logo = itemItems.MarketingAirline.Logo,
                                                            LogoFull = itemItems.MarketingAirline.LogoFull,
                                                            Name = itemItems.MarketingAirline.Name,
                                                            SystemId = itemItems.MarketingAirline.Id,
                                                            Thumbnail = itemItems.MarketingAirline.Thumbnail,
                                                            ThumbnailFull = itemItems.MarketingAirline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = true,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int marketingAirlineInsertId = airLinesRepository.Insert(marketingairline).ToInt32();
                                                        marketingairlineId = marketingAirlineInsertId;
                                                    }
                                                    else
                                                    {
                                                        marketingairlineId = controlmarketingairlines.Id;
                                                    }

                                                    #endregion

                                                    #region SegmentsInsert
                                                    SegmentsRepository segmentsRepository = new SegmentsRepository();
                                                    ServicesRepository servicesRepository = new ServicesRepository();
                                                    ExplanationsRepository explanationsRepository = new ExplanationsRepository();

                                                    foreach (var seg in itemItems.Segments)
                                                    {
                                                        Segments segment = new Segments()
                                                        {
                                                            AirCraft = seg.Aircraft,
                                                            AirLinesId = airlineId,
                                                            MarketingAirLineId = marketingairlineId,
                                                            Duration = seg.Duration,
                                                            ItemsId = controlItemsExistId,
                                                            FlightClassesId = classId,
                                                            FlightNo = seg.FlightNo,
                                                            PnlName = seg.PnlName,
                                                            DepartureId = departureId,
                                                            ArrivalId = arrivalId,

                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            UpdatedBy = 1,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            SystemId = seg.Id,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int segmentInsertId = segmentsRepository.Insert(segment).ToInt32();
                                                        segmentId = segmentInsertId;

                                                        #region ServicesInsert
                                                        foreach (var itemservice in seg.Services)
                                                        {
                                                            var servicename = servicesRepository.GetByName(itemservice.Name).FirstOrDefault();
                                                            if (servicename == null)
                                                            {
                                                                Services services = new Services
                                                                {
                                                                    ApiId = 1,
                                                                    CreatedBy = 1,
                                                                    CreatedDate = DateTime.Now,
                                                                    UpdatedDate = DateTime.Now,
                                                                    UpdatedBy = 1,
                                                                    LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                    OffersId = null,
                                                                    SegmentId = segmentInsertId,
                                                                    Name = itemservice.Name,
                                                                    Thumbnail = itemservice.Thumbnail,
                                                                    ThumbnailFull = itemservice.ThumbnailFull,
                                                                    SystemId = itemservice.Id
                                                                };
                                                                int serviceId = servicesRepository.Insert(services).ToInt32();

                                                                #region ExplanationsInsert
                                                                foreach (var itemexplanation in itemservice.Explanations)
                                                                {
                                                                    var explanationText = explanationsRepository.GetByText(itemexplanation.Text).FirstOrDefault();
                                                                    if (explanationText == null)
                                                                    {
                                                                        Explanations explanation = new Explanations()
                                                                        {
                                                                            ApiId = 1,
                                                                            CreatedBy = 1,
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedBy = 1,
                                                                            UpdatedDate = DateTime.Now,
                                                                            SegmentId = segmentInsertId,
                                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                            Text = itemexplanation.Text,
                                                                            ServiceId = serviceId
                                                                        };
                                                                        explanationsRepository.Insert(explanation).ToInt32();
                                                                    }
                                                                }
                                                                #endregion
                                                            }


                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region FlightClassInsert
                                                    var controlFlightclass = new FlightClassesRepository();
                                                    var name = controlFlightclass.GetByNameAndCode(itemItems.FlightClass.Name, itemItems.FlightClass.Code).FirstOrDefault();
                                                    if (name == null)
                                                    {
                                                        var flightClassId = controlFlightclass.Insert(new FlightClasses()
                                                        {
                                                            Code = itemItems.FlightClass.Code,
                                                            Name = itemItems.FlightClass.Name,
                                                            Type = itemItems.FlightClass.Type,
                                                            SystemId = item.Id,
                                                            FlightId = flightInsertedId,
                                                            FlightItemId = controlItemsExistId,
                                                            SegmentId = segmentId,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now

                                                        }).ToInt32();
                                                        classId = flightClassId;
                                                    }
                                                    else
                                                    {
                                                        classId = name.Id;
                                                    }
                                                    #endregion

                                                    #region BaggageInsert

                                                    using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                    {
                                                        foreach (var baggage in itemItems.BaggageInformations)
                                                        {
                                                            BaggageInformations baggageInformations = new BaggageInformations()
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                SystemId = "",
                                                                BaggageTypesId = baggage.BaggageType,
                                                                Weight = baggage.Weight,
                                                                BaggageUnitTypesId = baggage.UnitType,
                                                                PassengerTypesId = baggage.PassengerType,
                                                                Piece = baggage.Piece,
                                                                Descriptions = baggage.Description,
                                                                FlightId = flightInsertedId,
                                                                ItemsId = controlItemsExistId,
                                                                SegmentsId = segmentId,
                                                                OffersId = null,
                                                            };
                                                            baggageRepo.Insert(baggageInformations).ToInt32();
                                                            baggageList.Add(baggageInformations);
                                                        }
                                                    }
                                                    #endregion

                                                    #region PassengerInsert

                                                    foreach (var passenger in itemItems.Passengers)
                                                    {
                                                        Passengers passengers = new Passengers()
                                                        {
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            UpdatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            Count = passenger.Count,
                                                            PassengerTypesId = passenger.Type,
                                                            ItemsId = controlItemsExistId,
                                                        };
                                                        PassengersRepository passengersRepository = new PassengersRepository();
                                                        passengersRepository.Insert(passengers);
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                        #endregion

                                        #region OffersInsert
                                        int offerIds = 0;
                                        if (item.Offers != null && item.Offers.Any())
                                        {
                                            using (FlightOffersRepository offerRepository = new FlightOffersRepository())
                                            {
                                                foreach (var itemoffers in item.Offers)
                                                {

                                                    var itemOfferKeyExist = offerRepository.GetBySystemId(itemoffers.OfferId).FirstOrDefault();

                                                    if (itemOfferKeyExist == null)
                                                    {
                                                        int controlOfferKeyExistId = offerRepository.Insert(new FlightOffers()
                                                        {
                                                            SegmentNumber = itemoffers.SegmentNumber,
                                                            SingleAdultPrice = itemoffers.SingleAdultPrice.Amount,
                                                            ServiceFeesAmount = itemoffers.ServiceFee.Amount,
                                                            SeatInfosSeatCount = itemoffers.SeatInfo.AvailableSeatCount,
                                                            SeatInfosSeatCountType = itemoffers.SeatInfo.AvailableSeatCountType,
                                                            FlightProviderId = providerId,
                                                            OfferId = itemoffers.OfferId,
                                                            ExpiresOn = itemoffers.ExpiresOn.ToString(),
                                                            FlightsId = flightInsertedId,
                                                            IsPackageOffer = itemoffers.IsPackageOffer,
                                                            HasBrand = itemoffers.HasBrand,
                                                            Route = itemoffers.Route,
                                                            Provider = itemoffers.Provider,
                                                            Price = itemoffers.Price.Amount,
                                                            CurrencyId = 1,
                                                            ReservableInfo = itemoffers.ReservableInfo.Reservable,

                                                            ApiId = 1,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            SystemId = itemoffers.OfferId,
                                                        }).ToInt32();
                                                        offerIds = controlOfferKeyExistId;

                                                        foreach (var baggage in baggageList)
                                                        {
                                                            baggage.OffersId = offerIds;
                                                            using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                            {
                                                                baggageRepo.Update(baggage);
                                                            }
                                                        }
                                                        #region PriceBreakDownInsert
                                                        using (PriceBreakDownsRepository breakDownsRepository = new PriceBreakDownsRepository())
                                                        {
                                                            foreach (var itemPriceBreakDownItems in itemoffers.PriceBreakDown.Items)
                                                            {
                                                                PriceBreakDowns priceBreakDowns = new PriceBreakDowns
                                                                {
                                                                    ApiId = 1,
                                                                    LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                    UpdatedBy = 1,
                                                                    UpdatedDate = DateTime.Now,
                                                                    CreatedBy = 1,
                                                                    CreatedDate = DateTime.Now,
                                                                    Amount = itemPriceBreakDownItems.Price.Amount,
                                                                    CurrencyId = 1,
                                                                    FlightId = flightInsertedId,
                                                                    PassengerCount = itemPriceBreakDownItems.PassengerCount,
                                                                    PassengerTypeId = itemPriceBreakDownItems.PassengerType,
                                                                    OffersId = controlOfferKeyExistId
                                                                };
                                                                if (itemPriceBreakDownItems.AirportTax != null)
                                                                {
                                                                    priceBreakDowns.AirportTaxAmount = itemPriceBreakDownItems.AirportTax.Amount;
                                                                }
                                                                else
                                                                {
                                                                    priceBreakDowns.AirportTaxAmount = null;
                                                                }
                                                                int pricebreakDownId = breakDownsRepository.Insert(priceBreakDowns).ToInt32();
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                }
                                            }
                                        }

                                        #endregion
                                    }

                                }
                            }
                            #endregion

                            #region FlightPriceSearch Rountrip Insert

                            var GetPriceRoundtripSearch = JsonConvert.DeserializeObject<GetPriceSearchRoundtripRequest.Root>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\PriceSearchRoundTripFlight.json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var contentPriceSearchRound = JsonConvert.SerializeObject(GetPriceRoundtripSearch);
                            var bufferPriceSearchRound = Encoding.UTF8.GetBytes(contentPriceSearchRound);
                            var byteContentPriceSearchRound = new ByteArrayContent(bufferPriceSearchRound);
                            var reqPriceSearchRound = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContentPriceSearchRound);
                            var contentsPriceSearchRound = reqPriceSearchRound.Result.Content.ReadAsStringAsync().Result;

                            GetPriceSearchRountripResponse.Root roundtripSearch = JsonConvert.DeserializeObject<GetPriceSearchRountripResponse.Root>
(contentsPriceSearchRound);

                            foreach (var item in roundtripSearch.Body.Flights)
                            {
                                if (item != null)
                                {
                                    foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                    {

                                        #region Flight Insert
                                        var flightInsertedId = pricesearchFlightsRepositoryOneWay.Insert(new Flights()
                                        {
                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                            Provider = item.Provider,
                                            SystemId = item.Id,
                                            ApiId = 1,
                                            CreatedBy = 1,
                                            CreatedDate = DateTime.Now,
                                            UpdatedBy = 1,
                                            UpdatedDate = DateTime.Now,
                                            ProductType = 3,
                                            ServiceTypes = "2",
                                            AvailableSeatCount = item.AvailableSeatCount,
                                            AvailableSeatCountType = item.AvailableSeatCountType,
                                            ReservableInfo = item.ReservableInfo.Reservable
                                        }).ToInt32();
                                        #endregion

                                        #region GroupKeyInsert
                                        if (item.GroupKey != null && item.GroupKey.Any())
                                        {
                                            using (var keyRepo = new GroupKeysRepository())
                                            {
                                                foreach (var itemGroupKeys in item.GroupKey)
                                                {
                                                    var controlGroupKeyExist = keyRepo.GetByName(itemGroupKeys).FirstOrDefault();
                                                    if (controlGroupKeyExist == null)
                                                    {

                                                        int controlGroupKeyExistId = keyRepo.Insert(new GroupKeys()
                                                        {
                                                            FlightsId = flightInsertedId,
                                                            Name = itemGroupKeys,
                                                            SystemId = item.Id,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            FlightOffersId = 0
                                                        }).ToInt32();
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        List<BaggageInformations> baggageList = new List<BaggageInformations>();
                                        int providerId = 0;

                                        #region ItemsInsert
                                        if (item.Items != null && item.Items.Any())
                                        {
                                            using (var keyItemsRepo = new FlightItemsRepository())
                                            {

                                                foreach (var itemItems in item.Items)
                                                {
                                                    int classId = 0;
                                                    int airportDepartureId = 0;
                                                    int airportArrivalId = 0;
                                                    int airlineId = 0;
                                                    int marketingairlineId = 0;
                                                    int segmentId = 0;

                                                    #region AirportsInsert
                                                    using (AirPortsRepository airportRepoId = new AirPortsRepository())
                                                    {
                                                        var controlairportDeparture = airportRepoId.GetByName(itemItems.Departure.Airport.Name).FirstOrDefault();
                                                        var controlairportArrival = airportRepoId.GetByName(itemItems.Arrival.Airport.Name).FirstOrDefault();

                                                        if (controlairportDeparture == null)
                                                        {
                                                            AirPorts airPortDeparture = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = itemItems.Departure.Airport.Name,
                                                                SystemId = itemItems.Departure.Airport.Id,
                                                                Latitude = itemItems.Departure.GeoLocation.Latitude,
                                                                Longitude = itemItems.Departure.GeoLocation.Longitude,
                                                                Code = itemItems.Departure.Airport.Code

                                                            };
                                                            int airportDepartureControlId = airportRepoId.Insert(airPortDeparture).ToInt32();
                                                            airportDepartureId = airportDepartureControlId;
                                                        }
                                                        else
                                                        {
                                                            airportDepartureId = controlairportDeparture.Id;
                                                        }
                                                        if (controlairportArrival == null)
                                                        {
                                                            AirPorts airPortArrival = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = itemItems.Arrival.Airport.Name,
                                                                SystemId = itemItems.Arrival.Airport.Id,
                                                                Latitude = itemItems.Arrival.GeoLocation.Latitude,
                                                                Longitude = itemItems.Arrival.GeoLocation.Longitude,
                                                                Code = itemItems.Arrival.Airport.Code

                                                            };
                                                            int airportArrivalControlId = airportRepoId.Insert(airPortArrival).ToInt32();
                                                            airportArrivalId = airportArrivalControlId;
                                                        }
                                                        else
                                                        {
                                                            airportArrivalId = controlairportArrival.Id;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightProviderInsert
                                                    using (FlightProvidersRepository flightProviderRepository = new FlightProvidersRepository())
                                                    {
                                                        var providerControl = flightProviderRepository.GetByDisplayName(itemItems.FlightProvider.DisplayName).FirstOrDefault();
                                                        if (providerControl == null)
                                                        {
                                                            var flightProviderId = flightProviderRepository.Insert(new FlightProviders
                                                            {
                                                                DisplayName = itemItems.FlightProvider.DisplayName,
                                                                Name = itemItems.FlightProvider.Name,

                                                                SystemId = itemItems.FlightProvider.Id,
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                UpdatedBy = 1,
                                                                UpdatedDate = DateTime.Now
                                                            }).ToInt32();
                                                            providerId = flightProviderId;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightItemsInsert
                                                    var controlItemsExistId = keyItemsRepo.Insert(new FlightItems()
                                                    {
                                                        SegmentNumber = itemItems.SegmentNumber,
                                                        FlightNo = itemItems.FlightNo,
                                                        PnlName = itemItems.PnlName,
                                                        FlightDate = itemItems.FlightDate,
                                                        Duration = itemItems.Duration,
                                                        DayChange = itemItems.DayChange,
                                                        Route = itemItems.Route,
                                                        StopCount = itemItems.StopCount,
                                                        FlightType = itemItems.FlightType,
                                                        AirLinesId = itemItems.Airline.Id,
                                                        MarketingAirlines = itemItems.MarketingAirline.Id,
                                                        FlightClassesSystemId = itemItems.FlightClass.Id,

                                                        FlightsId = flightInsertedId,
                                                        FlightClassesId = classId,
                                                        FlightProviderId = providerId,
                                                        ProductType = 3,
                                                        ServiceTypes = "2",

                                                        SystemId = item.Id,
                                                        ApiId = 1,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now

                                                    }).ToInt32();
                                                    #endregion

                                                    #region DepartureInsert
                                                    DeparturesRepository departureRepository = new DeparturesRepository();
                                                    Departures departure = new Departures()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,

                                                        AirPortsId = airportDepartureId,
                                                        CountryId = itemCountry.Id,
                                                        Date = itemItems.Departure.Date,
                                                        Latitude = itemItems.Departure.GeoLocation.Latitude,
                                                        Longitude = itemItems.Departure.GeoLocation.Longitude,
                                                        CitySystemId = itemItems.Departure.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int departureId = departureRepository.Insert(departure).ToInt32();

                                                    #endregion

                                                    #region ArrivalInsert
                                                    ArrivalsRepositoy arrivalsRepository = new ArrivalsRepositoy();
                                                    Arrivals arrival = new Arrivals()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        AirPortsId = airportArrivalId,
                                                        CountryId = itemCountry.Id,
                                                        Date = itemItems.Arrival.Date,
                                                        Latitude = itemItems.Arrival.GeoLocation.Latitude,
                                                        Longitude = itemItems.Arrival.GeoLocation.Longitude,
                                                        CitySystemId = itemItems.Arrival.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int arrivalId = arrivalsRepository.Insert(arrival).ToInt32();

                                                    #endregion

                                                    #region AirlineInsert
                                                    var airLinesRepository = new AirLinesRepository();
                                                    var controlairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(itemItems.Airline.InternationalCode.ToString(), false).FirstOrDefault();

                                                    if (controlairlines == null)
                                                    {
                                                        var airline = new AirLines()
                                                        {
                                                            InterNationalCode = itemItems.Airline.InternationalCode,
                                                            Logo = itemItems.Airline.Logo,
                                                            LogoFull = itemItems.Airline.LogoFull,
                                                            Name = itemItems.Airline.Name,
                                                            SystemId = itemItems.Airline.Id,
                                                            Thumbnail = itemItems.Airline.Thumbnail,
                                                            ThumbnailFull = itemItems.Airline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = false,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int airlinenewInsertId = airLinesRepository.Insert(airline).ToInt32();

                                                        airlineId = airlinenewInsertId;
                                                    }
                                                    else
                                                    {
                                                        airlineId = controlairlines.Id;
                                                    }
                                                    var controlmarketingairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(itemItems.Airline.InternationalCode, true).FirstOrDefault();
                                                    if (controlmarketingairlines == null)
                                                    {
                                                        var marketingairline = new AirLines
                                                        {
                                                            InterNationalCode = itemItems.MarketingAirline.InternationalCode,
                                                            Logo = itemItems.MarketingAirline.Logo,
                                                            LogoFull = itemItems.MarketingAirline.LogoFull,
                                                            Name = itemItems.MarketingAirline.Name,
                                                            SystemId = itemItems.MarketingAirline.Id,
                                                            Thumbnail = itemItems.MarketingAirline.Thumbnail,
                                                            ThumbnailFull = itemItems.MarketingAirline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = true,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int marketingAirlineInsertId = airLinesRepository.Insert(marketingairline).ToInt32();
                                                        marketingairlineId = marketingAirlineInsertId;
                                                    }
                                                    else
                                                    {
                                                        marketingairlineId = controlmarketingairlines.Id;
                                                    }

                                                    #endregion

                                                    #region SegmentsInsert
                                                    SegmentsRepository segmentsRepository = new SegmentsRepository();
                                                    ServicesRepository servicesRepository = new ServicesRepository();
                                                    ExplanationsRepository explanationsRepository = new ExplanationsRepository();

                                                    foreach (var seg in itemItems.Segments)
                                                    {
                                                        Segments segment = new Segments()
                                                        {
                                                            AirCraft = seg.Aircraft,
                                                            AirLinesId = airlineId,
                                                            MarketingAirLineId = marketingairlineId,
                                                            Duration = seg.Duration,
                                                            ItemsId = controlItemsExistId,
                                                            FlightClassesId = classId,
                                                            FlightNo = seg.FlightNo,
                                                            PnlName = seg.PnlName,
                                                            DepartureId = departureId,
                                                            ArrivalId = arrivalId,

                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            UpdatedBy = 1,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            SystemId = seg.Id,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int segmentInsertId = segmentsRepository.Insert(segment).ToInt32();
                                                        segmentId = segmentInsertId;

                                                        #region ServicesInsert
                                                        foreach (var itemservice in seg.Services)
                                                        {
                                                            var servicename = servicesRepository.GetByName(itemservice.Name).FirstOrDefault();
                                                            if (servicename == null)
                                                            {
                                                                Services services = new Services
                                                                {
                                                                    ApiId = 1,
                                                                    CreatedBy = 1,
                                                                    CreatedDate = DateTime.Now,
                                                                    UpdatedDate = DateTime.Now,
                                                                    UpdatedBy = 1,
                                                                    LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                    OffersId = null,
                                                                    SegmentId = segmentInsertId,
                                                                    Name = itemservice.Name,
                                                                    Thumbnail = itemservice.Thumbnail,
                                                                    ThumbnailFull = itemservice.ThumbnailFull,
                                                                    SystemId = itemservice.Id
                                                                };
                                                                int serviceId = servicesRepository.Insert(services).ToInt32();

                                                                #region ExplanationsInsert
                                                                foreach (var itemexplanation in itemservice.Explanations)
                                                                {
                                                                    var explanationText = explanationsRepository.GetByText(itemexplanation.Text).FirstOrDefault();
                                                                    if (explanationText == null)
                                                                    {
                                                                        Explanations explanation = new Explanations()
                                                                        {
                                                                            ApiId = 1,
                                                                            CreatedBy = 1,
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedBy = 1,
                                                                            UpdatedDate = DateTime.Now,
                                                                            SegmentId = segmentInsertId,
                                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                            Text = itemexplanation.Text,
                                                                            ServiceId = serviceId
                                                                        };
                                                                        explanationsRepository.Insert(explanation).ToInt32();
                                                                    }
                                                                }
                                                                #endregion
                                                            }


                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region FlightClassInsert
                                                    var controlFlightclass = new FlightClassesRepository();
                                                    var name = controlFlightclass.GetByNameAndCode(itemItems.FlightClass.Name, itemItems.FlightClass.Code).FirstOrDefault();
                                                    if (name == null)
                                                    {
                                                        var flightClassId = controlFlightclass.Insert(new FlightClasses()
                                                        {
                                                            Code = itemItems.FlightClass.Code,
                                                            Name = itemItems.FlightClass.Name,
                                                            Type = itemItems.FlightClass.Type,
                                                            SystemId = item.Id,
                                                            FlightId = flightInsertedId,
                                                            FlightItemId = controlItemsExistId,
                                                            SegmentId = segmentId,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now

                                                        }).ToInt32();
                                                        classId = flightClassId;
                                                    }
                                                    else
                                                    {
                                                        classId = name.Id;
                                                    }
                                                    #endregion

                                                    #region BaggageInsert

                                                    using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                    {
                                                        foreach (var baggage in itemItems.BaggageInformations)
                                                        {
                                                            BaggageInformations baggageInformations = new BaggageInformations()
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                SystemId = "",
                                                                BaggageTypesId = baggage.BaggageType,
                                                                Weight = baggage.Weight,
                                                                BaggageUnitTypesId = baggage.UnitType,
                                                                PassengerTypesId = baggage.PassengerType,
                                                                Piece = baggage.Piece,
                                                                FlightId = flightInsertedId,
                                                                ItemsId = controlItemsExistId,
                                                                SegmentsId = segmentId,
                                                                OffersId = null
                                                            };
                                                            baggageRepo.Insert(baggageInformations).ToInt32();
                                                            baggageList.Add(baggageInformations);
                                                        }
                                                    }
                                                    #endregion

                                                    #region PassengerInsert

                                                    foreach (var passenger in itemItems.Passengers)
                                                    {
                                                        Passengers passengers = new Passengers()
                                                        {
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            UpdatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            Count = passenger.Count,
                                                            PassengerTypesId = passenger.Type,
                                                            ItemsId = controlItemsExistId
                                                        };
                                                        PassengersRepository passengersRepository = new PassengersRepository();
                                                        passengersRepository.Insert(passengers);
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                        #endregion

                                        #region OffersInsert
                                        int offerIds = 0;
                                        if (item.Offer != null)
                                        {
                                            using (FlightOffersRepository offerRepository = new FlightOffersRepository())
                                            {

                                                var itemOfferKeyExist = offerRepository.GetBySystemId(item.Offer.OfferId).FirstOrDefault();

                                                if (itemOfferKeyExist == null)
                                                {
                                                    int controlOfferKeyExistId = offerRepository.Insert(new FlightOffers()
                                                    {
                                                        SegmentNumber = item.Offer.SegmentNumber,
                                                        SingleAdultPrice = item.Offer.SingleAdultPrice.Amount,
                                                        OfferId = item.Offer.OfferId,
                                                        ExpiresOn = item.Offer.ExpiresOn.ToString(),
                                                        FlightsId = flightInsertedId,
                                                        Route = item.Offer.Route,
                                                        Provider = item.Offer.Provider,
                                                        Price = item.Offer.Price.Amount,

                                                        CurrencyId = 1,
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        SystemId = item.Offer.OfferId,
                                                    }).ToInt32();
                                                    offerIds = controlOfferKeyExistId;

                                                    foreach (var baggage in baggageList)
                                                    {
                                                        baggage.OffersId = offerIds;
                                                        using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                        {
                                                            baggageRepo.Update(baggage);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion

                            #region FlightPriceSearch MultiCity Insert

                            var flightsRepositoryMultiCity = new FlightsRepository();
                            var GetPriceMultiSearch = JsonConvert.DeserializeObject<GetPriceSearchMulticityRequest.Root>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\PriceSearchMultiCityFlight.json"));

                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var contentPriceSearchMulti = JsonConvert.SerializeObject(GetPriceMultiSearch);
                            var bufferPriceSearchMulti = Encoding.UTF8.GetBytes(contentPriceSearchMulti);
                            var byteContentPriceSearchMulti = new ByteArrayContent(bufferPriceSearchMulti);
                            var reqPriceSearchMulti = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContentPriceSearchMulti);
                            var contentsPriceSearchMulti = reqPriceSearchMulti.Result.Content.ReadAsStringAsync().Result;
                            GetPriceSearchMulticityResponse.Root multiSearch = JsonConvert.DeserializeObject<GetPriceSearchMulticityResponse.Root>
(contentsPriceSearchMulti);

                            foreach (var flight in multiSearch.Body.Flights)
                            {
                                if (flight != null)
                                {
                                    foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                    {
                                        #region Flight Insert

                                        Flights flights = new Flights
                                        {
                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                            Provider = flight.Provider,
                                            SystemId = flight.Id,
                                            ApiId = 1,
                                            CreatedBy = 1,
                                            CreatedDate = DateTime.Now,
                                            UpdatedBy = 1,
                                            UpdatedDate = DateTime.Now,
                                            ProductType = 3,
                                            ServiceTypes = "3",
                                            AvailableSeatCount = flight.AvailableSeatCount,
                                            AvailableSeatCountType = flight.AvailableSeatCountType
                                        };
                                        if (flight.ReservableInfo == null)
                                        {
                                            flights.ReservableInfo = null;
                                        }
                                        else
                                        {
                                            flights.ReservableInfo = flight.ReservableInfo.Reservable;
                                        }
                                        int flightInsertedId = flightsRepositoryMultiCity.Insert(flights).ToInt32();
                                        #endregion

                                        #region GroupKey Insert
                                        if (flight.GroupKey != null && flight.GroupKey.Any())
                                        {
                                            using (var keyRepo = new GroupKeysRepository())
                                            {
                                                foreach (var itemGroupKeys in flight.GroupKey)
                                                {
                                                    var controlGroupKeyExist = keyRepo.GetByName(itemGroupKeys).FirstOrDefault();
                                                    if (controlGroupKeyExist == null)
                                                    {

                                                        int controlGroupKeyExistId = keyRepo.Insert(new GroupKeys()
                                                        {
                                                            FlightsId = flightInsertedId,
                                                            Name = itemGroupKeys,
                                                            SystemId = flight.Id,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            FlightOffersId = 0
                                                        }).ToInt32();
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        List<BaggageInformations> baggageList = new List<BaggageInformations>();

                                        #region Items Insert
                                        if (flight.Items != null && flight.Items.Any())
                                        {
                                            using (var keyItemsRepo = new FlightItemsRepository())
                                            {
                                                foreach (var item in flight.Items)
                                                {
                                                    int classId = 0;
                                                    int airportDepartureId = 0;
                                                    int airportArrivalId = 0;
                                                    int airlineId = 0;
                                                    int marketingairlineId = 0;
                                                    int segmentId = 0;
                                                    int providerId = 0;

                                                    #region AirportsInsert
                                                    using (AirPortsRepository airportRepoId = new AirPortsRepository())
                                                    {
                                                        var controlairportDeparture = airportRepoId.GetByName(item.Departure.Airport.Name).FirstOrDefault();
                                                        var controlairportArrival = airportRepoId.GetByName(item.Arrival.Airport.Name).FirstOrDefault();

                                                        if (controlairportDeparture == null)
                                                        {
                                                            AirPorts airPortDeparture = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = item.Departure.Airport.Name,
                                                                SystemId = item.Departure.Airport.Id,
                                                                Latitude = item.Departure.GeoLocation.Latitude,
                                                                Longitude = item.Departure.GeoLocation.Longitude,
                                                                Code = item.Departure.Airport.Code

                                                            };
                                                            int airportDepartureControlId = airportRepoId.Insert(airPortDeparture).ToInt32();
                                                            airportDepartureId = airportDepartureControlId;
                                                        }
                                                        else
                                                        {
                                                            airportDepartureId = controlairportDeparture.Id;
                                                        }
                                                        if (controlairportArrival == null)
                                                        {
                                                            AirPorts airPortArrival = new AirPorts
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                Name = item.Arrival.Airport.Name,
                                                                SystemId = item.Arrival.Airport.Id,
                                                                Latitude = item.Arrival.GeoLocation.Latitude,
                                                                Longitude = item.Arrival.GeoLocation.Longitude,
                                                                Code = item.Arrival.Airport.Code

                                                            };
                                                            int airportArrivalControlId = airportRepoId.Insert(airPortArrival).ToInt32();
                                                            airportArrivalId = airportArrivalControlId;
                                                        }
                                                        else
                                                        {
                                                            airportArrivalId = controlairportArrival.Id;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightProvider Insert
                                                    using (FlightProvidersRepository flightProviderRepository = new FlightProvidersRepository())
                                                    {
                                                        var providerControl = flightProviderRepository.GetByDisplayName(item.FlightProvider.DisplayName).FirstOrDefault();
                                                        if (providerControl == null)
                                                        {
                                                            var flightProviderId = flightProviderRepository.Insert(new FlightProviders
                                                            {
                                                                DisplayName = item.FlightProvider.DisplayName,
                                                                Name = item.FlightProvider.Name,

                                                                SystemId = item.FlightProvider.Id,
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                UpdatedBy = 1,
                                                                UpdatedDate = DateTime.Now
                                                            }).ToInt32();
                                                            providerId = flightProviderId;
                                                        }
                                                    }
                                                    #endregion

                                                    #region FlightItemsInsert
                                                    var controlItemsExistId = keyItemsRepo.Insert(new FlightItems()
                                                    {
                                                        SegmentNumber = item.SegmentNumber,
                                                        FlightNo = item.FlightNo,
                                                        PnlName = item.PnlName,
                                                        FlightDate = item.FlightDate,
                                                        Duration = item.Duration,
                                                        DayChange = item.DayChange,
                                                        Route = item.Route,
                                                        StopCount = item.StopCount,
                                                        FlightType = item.FlightType,
                                                        AirLinesId = item.Airline.Id,
                                                        MarketingAirlines = item.MarketingAirline.Id,
                                                        FlightClassesSystemId = item.FlightClass.Id,

                                                        FlightsId = flightInsertedId,
                                                        FlightClassesId = classId,
                                                        FlightProviderId = providerId,
                                                        ProductType = 3,
                                                        ServiceTypes = "3",

                                                        SystemId = flight.Id,
                                                        ApiId = 1,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now
                                                    }).ToInt32();
                                                    #endregion

                                                    #region DepartureInsert
                                                    DeparturesRepository departureRepository = new DeparturesRepository();
                                                    Departures departure = new Departures()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,

                                                        AirPortsId = airportDepartureId,
                                                        CountryId = itemCountry.Id,
                                                        Date = item.Departure.Date,
                                                        Latitude = item.Departure.GeoLocation.Latitude,
                                                        Longitude = item.Departure.GeoLocation.Longitude,
                                                        CitySystemId = item.Departure.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int departureId = departureRepository.Insert(departure).ToInt32();

                                                    #endregion

                                                    #region ArrivalInsert
                                                    ArrivalsRepositoy arrivalsRepository = new ArrivalsRepositoy();
                                                    Arrivals arrival = new Arrivals()
                                                    {
                                                        SystemId = "?",
                                                        ApiId = 1,
                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                        UpdatedBy = 1,
                                                        UpdatedDate = DateTime.Now,
                                                        CreatedBy = 1,
                                                        CreatedDate = DateTime.Now,
                                                        AirPortsId = airportArrivalId,
                                                        CountryId = itemCountry.Id,
                                                        Date = item.Arrival.Date,
                                                        Latitude = item.Arrival.GeoLocation.Latitude,
                                                        Longitude = item.Arrival.GeoLocation.Longitude,
                                                        CitySystemId = item.Arrival.City.Id,
                                                        FlightItemsId = controlItemsExistId,
                                                        FlightId = flightInsertedId
                                                    };
                                                    int arrivalId = arrivalsRepository.Insert(arrival).ToInt32();

                                                    #endregion

                                                    #region AirlineInsert
                                                    var airLinesRepository = new AirLinesRepository();
                                                    var controlairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(item.Airline.InternationalCode.ToString(), false).FirstOrDefault();

                                                    if (controlairlines == null)
                                                    {
                                                        var airline = new AirLines()
                                                        {
                                                            InterNationalCode = item.Airline.InternationalCode,
                                                            Logo = item.Airline.Logo,
                                                            LogoFull = item.Airline.LogoFull,
                                                            Name = item.Airline.Name,
                                                            SystemId = item.Airline.Id,
                                                            Thumbnail = item.Airline.Thumbnail,
                                                            ThumbnailFull = item.Airline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = false,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int airlinenewInsertId = airLinesRepository.Insert(airline).ToInt32();

                                                        airlineId = airlinenewInsertId;
                                                    }
                                                    else
                                                    {
                                                        airlineId = controlairlines.Id;
                                                    }
                                                    var controlmarketingairlines = airLinesRepository.AirLinesGetByInterNationalIsMarketing(item.Airline.InternationalCode, true).FirstOrDefault();
                                                    if (controlmarketingairlines == null)
                                                    {
                                                        var marketingairline = new AirLines
                                                        {
                                                            InterNationalCode = item.MarketingAirline.InternationalCode,
                                                            Logo = item.MarketingAirline.Logo,
                                                            LogoFull = item.MarketingAirline.LogoFull,
                                                            Name = item.MarketingAirline.Name,
                                                            SystemId = item.MarketingAirline.Id,
                                                            Thumbnail = item.MarketingAirline.Thumbnail,
                                                            ThumbnailFull = item.MarketingAirline.ThumbnailFull,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            ItemsId = controlItemsExistId,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            IsMarketing = true,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int marketingAirlineInsertId = airLinesRepository.Insert(marketingairline).ToInt32();
                                                        marketingairlineId = marketingAirlineInsertId;
                                                    }
                                                    else
                                                    {
                                                        marketingairlineId = controlmarketingairlines.Id;
                                                    }

                                                    #endregion

                                                    #region SegmentsInsert
                                                    SegmentsRepository segmentsRepository = new SegmentsRepository();
                                                    ServicesRepository servicesRepository = new ServicesRepository();
                                                    ExplanationsRepository explanationsRepository = new ExplanationsRepository();

                                                    foreach (var seg in item.Segments)
                                                    {
                                                        Segments segment = new Segments()
                                                        {
                                                            AirCraft = seg.Aircraft,
                                                            AirLinesId = airlineId,
                                                            MarketingAirLineId = marketingairlineId,
                                                            Duration = seg.Duration,
                                                            ItemsId = controlItemsExistId,
                                                            FlightClassesId = classId,
                                                            FlightNo = seg.FlightNo,
                                                            PnlName = seg.PnlName,
                                                            DepartureId = departureId,
                                                            ArrivalId = arrivalId,

                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            UpdatedBy = 1,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            SystemId = seg.Id,
                                                            FlightId = flightInsertedId
                                                        };
                                                        int segmentInsertId = segmentsRepository.Insert(segment).ToInt32();
                                                        segmentId = segmentInsertId;

                                                        #region ServicesInsert
                                                        foreach (var itemservice in seg.Services)
                                                        {
                                                            var servicename = servicesRepository.GetByName(itemservice.Name).FirstOrDefault();
                                                            if (servicename == null)
                                                            {
                                                                Services services = new Services
                                                                {
                                                                    ApiId = 1,
                                                                    CreatedBy = 1,
                                                                    CreatedDate = DateTime.Now,
                                                                    UpdatedDate = DateTime.Now,
                                                                    UpdatedBy = 1,
                                                                    LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                    OffersId = null,
                                                                    SegmentId = segmentInsertId,
                                                                    Name = itemservice.Name,
                                                                    Thumbnail = itemservice.Thumbnail,
                                                                    ThumbnailFull = itemservice.ThumbnailFull,
                                                                    SystemId = itemservice.Id
                                                                };
                                                                int serviceId = servicesRepository.Insert(services).ToInt32();

                                                                #region ExplanationsInsert
                                                                foreach (var itemexplanation in itemservice.Explanations)
                                                                {
                                                                    var explanationText = explanationsRepository.GetByText(itemexplanation.Text).FirstOrDefault();
                                                                    if (explanationText == null)
                                                                    {
                                                                        Explanations explanation = new Explanations()
                                                                        {
                                                                            ApiId = 1,
                                                                            CreatedBy = 1,
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedBy = 1,
                                                                            UpdatedDate = DateTime.Now,
                                                                            SegmentId = segmentInsertId,
                                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                            Text = itemexplanation.Text,
                                                                            ServiceId = serviceId
                                                                        };
                                                                        explanationsRepository.Insert(explanation).ToInt32();
                                                                    }
                                                                }
                                                                #endregion
                                                            }


                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region FlightClassInsert
                                                    var controlFlightclass = new FlightClassesRepository();
                                                    var name = controlFlightclass.GetByNameAndCode(item.FlightClass.Name, item.FlightClass.Code).FirstOrDefault();
                                                    if (name == null)
                                                    {
                                                        var flightClassId = controlFlightclass.Insert(new FlightClasses()
                                                        {
                                                            Code = item.FlightClass.Code,
                                                            Name = item.FlightClass.Name,
                                                            Type = item.FlightClass.Type,
                                                            SystemId = flight.Id,
                                                            FlightId = flightInsertedId,
                                                            FlightItemId = controlItemsExistId,
                                                            SegmentId = segmentId,
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now

                                                        }).ToInt32();
                                                        classId = flightClassId;
                                                    }
                                                    else
                                                    {
                                                        classId = name.Id;
                                                    }
                                                    #endregion

                                                    #region BaggageInsert

                                                    using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                    {
                                                        foreach (var baggage in item.BaggageInformations)
                                                        {
                                                            BaggageInformations baggageInformations = new BaggageInformations()
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                SystemId = "",
                                                                BaggageTypesId = baggage.BaggageType,
                                                                Weight = baggage.Weight,
                                                                BaggageUnitTypesId = baggage.UnitType,
                                                                PassengerTypesId = baggage.PassengerType,
                                                                Piece = baggage.Piece,
                                                                FlightId = flightInsertedId,
                                                                ItemsId = controlItemsExistId,
                                                                SegmentsId = segmentId,
                                                                OffersId = null
                                                            };
                                                            baggageRepo.Insert(baggageInformations).ToInt32();
                                                            baggageList.Add(baggageInformations);
                                                        }
                                                    }
                                                    #endregion

                                                    #region PassengerInsert

                                                    foreach (var passenger in item.Passengers)
                                                    {
                                                        Passengers passengers = new Passengers()
                                                        {
                                                            ApiId = 1,
                                                            CreatedBy = 1,
                                                            UpdatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            Count = passenger.Count,
                                                            PassengerTypesId = passenger.Type,
                                                            ItemsId = controlItemsExistId
                                                        };
                                                        PassengersRepository passengersRepository = new PassengersRepository();
                                                        passengersRepository.Insert(passengers);
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                        #endregion


                                        #region Offers Insert
                                        if (flight.Offers != null)
                                        {
                                            foreach (var offer in flight.Offers)
                                            {
                                                int offerIds = 0;
                                                using (FlightOffersRepository offerRepository = new FlightOffersRepository())
                                                {

                                                    var itemOfferKeyExist = offerRepository.GetBySystemId(offer.OfferId).FirstOrDefault();

                                                    if (itemOfferKeyExist == null)
                                                    {
                                                        #region FlightBrand Insert

                                                        FlightBrands flightBrands = new FlightBrands
                                                        {
                                                            SystemId = offer.FlightBrandInfo.Id,
                                                            Name = offer.FlightBrandInfo.Name,
                                                            FlightId = flightInsertedId,
                                                            UpdatedBy = 1,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            UpdatedDate = DateTime.Now,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            ApiId = 1
                                                        };
                                                        FlightBrandsRepository flightBrandsRepository = new FlightBrandsRepository();
                                                        int flightbrandId = flightBrandsRepository.Insert(flightBrands).ToInt32();

                                                        #endregion

                                                        int controlOfferKeyExistId = offerRepository.Insert(new FlightOffers()
                                                        {
                                                            SegmentNumber = offer.SegmentNumber,
                                                            SingleAdultPrice = offer.SingleAdultPrice.Amount,
                                                            OfferId = offer.OfferId,
                                                            ExpiresOn = offer.ExpiresOn.ToString(),
                                                            FlightsId = flightInsertedId,
                                                            Route = offer.Route,
                                                            Provider = offer.Provider,
                                                            Price = offer.Price.Amount,
                                                            FlightBrandsId = flightbrandId,
                                                            FlightProviderId = null,
                                                            PriceBreakDownId = null,
                                                            CurrencyId = 1,
                                                            ApiId = 1,
                                                            LanguageId = (int)itemCountry.DefaultLanguageId,
                                                            UpdatedBy = 1,
                                                            UpdatedDate = DateTime.Now,
                                                            CreatedBy = 1,
                                                            CreatedDate = DateTime.Now,
                                                            SystemId = offer.OfferId,
                                                        }).ToInt32();
                                                        offerIds = controlOfferKeyExistId;

                                                        foreach (var baggage in baggageList)
                                                        {
                                                            baggage.OffersId = offerIds;
                                                            using (BaggageInformationsRepository baggageRepo = new BaggageInformationsRepository())
                                                            {
                                                                baggageRepo.Update(baggage);
                                                            }
                                                        }

                                                        #region PriceBreakDownInsert

                                                        using (PriceBreakDownsRepository breakDownsRepository = new PriceBreakDownsRepository())
                                                        {
                                                            int pricebreakDownId = 0;
                                                            foreach (var itemPriceBreakDownItems in offer.PriceBreakDown.Items)
                                                            {
                                                                PriceBreakDowns priceBreakDowns = new PriceBreakDowns
                                                                {
                                                                    ApiId = 1,
                                                                    LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                    UpdatedBy = 1,
                                                                    UpdatedDate = DateTime.Now,
                                                                    CreatedBy = 1,
                                                                    CreatedDate = DateTime.Now,
                                                                    Amount = itemPriceBreakDownItems.Price.Amount,
                                                                    CurrencyId = 1,
                                                                    FlightId = flightInsertedId,
                                                                    PassengerCount = itemPriceBreakDownItems.PassengerCount,
                                                                    PassengerTypeId = itemPriceBreakDownItems.PassengerType,
                                                                    AirportTaxAmount = itemPriceBreakDownItems.AirportTax.Amount,
                                                                    OffersId = offerIds
                                                                };
                                                                if (itemPriceBreakDownItems.AirportTax != null)
                                                                {
                                                                    priceBreakDowns.AirportTaxAmount = itemPriceBreakDownItems.AirportTax.Amount;
                                                                }
                                                                else
                                                                {
                                                                    priceBreakDowns.AirportTaxAmount = null;
                                                                }
                                                                pricebreakDownId = breakDownsRepository.Insert(priceBreakDowns).ToInt32();
                                                            }
                                                        }
                                                        #endregion

                                                        #region Services Insert

                                                        foreach (var service in offer.Services)
                                                        {

                                                            Services services = new Services
                                                            {
                                                                ApiId = 1,
                                                                CreatedBy = 1,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                UpdatedBy = 1,
                                                                LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                OffersId = null,
                                                                SegmentId = null,
                                                                Name = service.Name,
                                                                Thumbnail = service.Thumbnail,
                                                                ThumbnailFull = service.ThumbnailFull,
                                                                SystemId = service.Id
                                                            };
                                                            ServicesRepository servicesRepository = new ServicesRepository();
                                                            int serviceId = servicesRepository.Insert(services).ToInt32();

                                                            #region ExplanationsInsert
                                                            foreach (var serviceexplanation in service.Explanations)
                                                            {
                                                                ExplanationsRepository explanationsRepository = new ExplanationsRepository();
                                                                var explanationText = explanationsRepository.GetByText(serviceexplanation.Text).FirstOrDefault();
                                                                if (explanationText == null)
                                                                {
                                                                    Explanations explanation = new Explanations()
                                                                    {
                                                                        ApiId = 1,
                                                                        CreatedBy = 1,
                                                                        CreatedDate = DateTime.Now,
                                                                        UpdatedBy = 1,
                                                                        UpdatedDate = DateTime.Now,
                                                                        SegmentId = null,
                                                                        LanguageId = (int)itemCountry.DefaultLanguageId,
                                                                        Text = serviceexplanation.Text,
                                                                        ServiceId = serviceId
                                                                    };
                                                                    explanationsRepository.Insert(explanation).ToInt32();
                                                                }
                                                            }
                                                            #endregion

                                                        }
                                                        #endregion

                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion

                            #region GetOffers

                            //GetOffersFlightRequest GetPriceOffersSearch = JsonConvert.DeserializeObject<GetOffersFlightRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\GetOffersFlight.json"));
                            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            //var contentPriceSearchOffers = JsonConvert.SerializeObject(GetPriceOffersSearch);
                            //var bufferPriceSearchOffers = Encoding.UTF8.GetBytes(contentPriceSearchOffers);
                            //var byteContentPriceSearchOffers = new ByteArrayContent(bufferPriceSearchOffers);
                            //var reqPriceSearchOffers = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getoffers", byteContentPriceSearchOffers);
                            //var contentsPriceSearchOffers = reqPriceSearchOffers.Result.Content.ReadAsStringAsync().Result;

                            //ApiCrawler.Paximum.App_Code.Paximum.FlightResponse.GetOffersFlightResponse.Root GetOffersFlightResponse = JsonConvert.DeserializeObject<ApiCrawler.Paximum.App_Code.Paximum.FlightResponse.GetOffersFlightResponse.Root>(contentsPriceSearchOffers);

                            #endregion
                        }
                    }
                }

            }
        }
    }
}