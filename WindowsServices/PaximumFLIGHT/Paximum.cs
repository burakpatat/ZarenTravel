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
using System.Web;
using Request.ByHotel;
using Paximum.Response.PriceSearch;
using Paximum.Enums;
using Paximum.Request;
using Paximum.Response;
using Request.ByLocation;
using ApiCrawler.Paximum.App_Code.Paximum.Response;

using Model.Concrete;
using HotelProduct;
using Paximum.Response.Hotel;
using Paximum.Response.OfferDetail;
using System.CodeDom;
using System.Web.UI.WebControls;

namespace Api.Paximum
{
    public partial class Paximum : ServiceBase
    {
        IDbConnection connection;


        public Paximum()
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
            this.OnStop();
        }
        public void RunYourCode()
        {

            var autoCompleteRepository = new AutoCompletesRepository();
            var currencyRepository = new CurrencyRepository();
            #region LoginProcess
            var bodyData = new ApiCrawler.Authentication.LoginResponse();
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

                    #region HotelApi
                    if (itemType.Value == 2)
                    {
                        var GetArrivalAutocomplete = JsonConvert.DeserializeObject<GetArrivalAutocompleteRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\GetArrivalAutocomplete.json"));
                        GetArrivalAutocomplete.ProductType = 2;
                        GetArrivalAutocomplete.Culture = itemCulture.CountryCode;

                        var list = new PossibleQueryRepository().GetAll().Where(a => a.Query == "ant");
                        var iCount = 0;
                        foreach (var possibleQuery in list)
                        {
                            GetArrivalAutocomplete.Query = possibleQuery.Query;

                            var client = new HttpClient();
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                            var content = JsonConvert.SerializeObject(GetArrivalAutocomplete);
                            var buffer = Encoding.UTF8.GetBytes(content);
                            var byteContent = new ByteArrayContent(buffer);
                            var req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete", byteContent);
                            var contents = req.Result.Content.ReadAsStringAsync().Result;
                            GetArrivalAutocompleteResponse GetArrivalAutocompleteResponse = JsonConvert.DeserializeObject<GetArrivalAutocompleteResponse>(contents);

                            foreach (var item in GetArrivalAutocompleteResponse.Body.Items)
                            {

                                foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                {

                                    #region AutoCompleteData
                                    if (item.City != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(item?.City?.Name).Where(a => a.Name == item.City?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = item.City?.Id,
                                                Name = item.City?.Name,
                                                SystemType = item.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.City,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }
                                    }
                                    if (item.State != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(item?.State?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = item.State?.Id,
                                                Name = item.State?.Name,
                                                SystemType = item.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.State,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }

                                    }
                                    if (item.Country != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(item?.Country?.Name).Where(a => a.Name == item?.Country?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = item.Country?.Id,
                                                Name = item.Country?.Name,
                                                SystemType = item.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.Country,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }
                                    }
                                    #endregion

                                    foreach (var currencyItem in currencyRepository.GetAll().Where(a => a.CurrencyCode == "EUR").ToList())
                                    {
                                        int i = 7;
                                        int year = 150;
                                        int adult = 2;

                                        #region PriceSearch
                                        var priceSearchLocation = JsonConvert.DeserializeObject<PriceSearchByLocationRequest>(File.ReadAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\pricesearch.json"));
                                        priceSearchLocation.CheckIn = DateTime.Now.Date.AddDays(year).ToString("yyyy-MM-dd");
                                        priceSearchLocation.Night = i;
                                        priceSearchLocation.Culture = itemCulture.CountryCode;
                                        priceSearchLocation.ProductType = 2;
                                        priceSearchLocation.Currency = currencyItem.CurrencyCode;
                                        priceSearchLocation.CheckAllotment = false;
                                        priceSearchLocation.CheckStopSale = false;
                                        priceSearchLocation.GetOnlyDiscountedPrice = false;
                                        priceSearchLocation.GetOnlyBestOffers = false;
                                        priceSearchLocation.Nationality = itemCountry.ShortName;

                                        priceSearchLocation.RoomCriteria = new List<Request.ByLocation.RoomCriterion>();
                                        var Roomcriteria = new Request.ByLocation.RoomCriterion();
                                        Roomcriteria.Adult = adult;
                                        priceSearchLocation.RoomCriteria.Add(Roomcriteria);

                                        priceSearchLocation.ArrivalLocations = new List<ArrivalLocation>();
                                        if (item.GiataInfo == null)
                                        {
                                            priceSearchLocation.ArrivalLocations.Add(new ArrivalLocation()
                                            {
                                                Id = item.City.Id,
                                                Type = item.Type
                                            });
                                        }
                                        else
                                        {
                                            priceSearchLocation.ArrivalLocations.Add(new ArrivalLocation()
                                            {
                                                Id = item.GiataInfo.HotelId,
                                                Type = item.Type
                                            });
                                        }
                                        try
                                        {
                                            var requestDate = DateTime.Now;
                                            client = new HttpClient();

                                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                                            content = JsonConvert.SerializeObject(priceSearchLocation);
                                            buffer = Encoding.UTF8.GetBytes(content);
                                            byteContent = new ByteArrayContent(buffer);
                                            req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent);
                                            contents = req.Result.Content.ReadAsStringAsync().Result;

                                            PriceSearchResponse obj = JsonConvert.DeserializeObject<PriceSearchResponse>(contents);
                                            var responseDate = DateTime.Now;
                                            var model = new ApiResults()
                                            {
                                                RequestData = content,
                                                ResponseData = contents,
                                                RequestDate = requestDate,
                                                ResponseDate = responseDate,
                                                Currency = priceSearchLocation.Currency,
                                                CheckIn = priceSearchLocation.CheckIn.ToString(),
                                                Nationality = "TR",
                                                ApiId = (int)ApiType.Paximum,
                                                IsSuccessfull = obj.header?.success,
                                                LocationId = item.City?.Id,
                                                Query = GetArrivalAutocomplete.Query + ":" + JsonConvert.SerializeObject(item),
                                                ProductType = 2
                                            };

                                            using (var repo = new ApiResultsRepository())
                                            {
                                                var controlResp = repo.GetByLocationId(item.City?.Id.ToInt32()).FirstOrDefault();
                                                if (controlResp == null)
                                                    repo.Insert(model);
                                            }
                                            #endregion

                                            if (obj != null && obj.body != null && obj.body.hotels != null && obj.body.hotels.Any())
                                            {
                                                foreach (var hotels in obj.body.hotels)
                                                {
                                                    #region ProductInfo
                                                    GetProductInfoRequest getProductInfoRequest = new GetProductInfoRequest();
                                                    getProductInfoRequest.Culture = itemCulture.CountryCode;
                                                    getProductInfoRequest.Product = hotels.id;
                                                    getProductInfoRequest.ProductType = 2;
                                                    getProductInfoRequest.OwnerProvider = 2;
                                                    client = new HttpClient();

                                                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                                                    content = JsonConvert.SerializeObject(getProductInfoRequest);
                                                    buffer = Encoding.UTF8.GetBytes(content);
                                                    byteContent = new ByteArrayContent(buffer);
                                                    req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getproductinfo", byteContent);
                                                    contents = req.Result.Content.ReadAsStringAsync().Result;
                                                    HotelProductResponse HotelProduct = JsonConvert.DeserializeObject<HotelProductResponse>(contents);
                                                    var hotel = HotelProduct.Body.Hotel;
                                                    int insertedSeasonId = 0;
                                                    #region Hotel
                                                    using (var context = new HotelsRepository())
                                                    {
                                                        var controlGiadata = context.GetByGiataId(hotels.giataInfo.hotelId).FirstOrDefault();
                                                        if (controlGiadata == null)
                                                        {
                                                            var hotelModel = new Hotels()
                                                            {
                                                                SystemId = hotels.id,
                                                                Name = hotel.Name,
                                                                ApiId = (int)ApiType.Paximum,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                GiataId = hotels.giataInfo?.hotelId,
                                                                FaxNumber = hotel.FaxNumber,
                                                                CreatedDate = DateTime.Now,
                                                                HomePage = hotel.HomePage,
                                                                PhoneNumber = hotel.PhoneNumber,
                                                                Provider = hotel.Provider,
                                                                StopSaleGuaranteed = hotel.StopSaleGuaranteed,
                                                                StopSaleStandart = hotel.StopSaleStandart,
                                                                Statu = 1,
                                                                Thumbnail = hotel.Thumbnail,
                                                                ThumbnailFull = hotel.ThumbnailFull,
                                                                UpdatedDate = DateTime.Now
                                                            };
                                                            context.Insert(hotelModel);

                                                            if (hotel.Name != null)
                                                            {
                                                                var controlItem = autoCompleteRepository.GetByName(hotel.Name).FirstOrDefault();
                                                                if (controlItem == null)
                                                                {
                                                                    autoCompleteRepository.Insert(new AutoCompletes()
                                                                    {
                                                                        ApiId = (int)ApiType.Paximum,
                                                                        SystemId = hotels.id,
                                                                        Name = hotel.Name,
                                                                        SystemType = item.Type.ToString(),
                                                                        Type = (int)AutoCompleteTypes.Hotel,
                                                                        LanguageId = itemCountry.DefaultLanguageId
                                                                    });
                                                                }
                                                            }
                                                        }

                                                    }
                                                    #endregion
                                                    #region Seasons
                                                    if (hotel.Seasons != null)
                                                    {
                                                        foreach (var itemSeasons in hotel.Seasons)
                                                        {
                                                            using (var context = new HotelSeasonsRepository())
                                                            {
                                                                var controlSeason = context.GetByHotelId(hotel.Id.ToInt32()).Where(a => a.BeginDate == Convert.ToDateTime(itemSeasons.BeginDate.ToString("yyyy-MM-dd")) && a.EndDate == Convert.ToDateTime(itemSeasons.EndDate.ToString("yyyy-MM-dd"))).FirstOrDefault();
                                                                if (controlSeason == null)
                                                                {
                                                                    var hotelSeasons = new Model.Concrete.HotelSeasons()
                                                                    {
                                                                        SystemId = itemSeasons.Id.ToString(),
                                                                        Name = itemSeasons.Name,
                                                                        ApiId = (int)ApiType.Paximum,
                                                                        CreatedBy = 1,
                                                                        UpdatedBy = 1,
                                                                        LanguageId = itemCountry.DefaultLanguageId,
                                                                        CreatedDate = DateTime.Now,
                                                                        HotelId = hotels.id.ToInt32(),
                                                                        UpdatedDate = DateTime.Now,
                                                                        Type = 2
                                                                    };

                                                                    if (itemSeasons.BeginDate != null && itemSeasons.BeginDate > DateTime.MinValue)
                                                                        hotelSeasons.BeginDate = Convert.ToDateTime(itemSeasons.BeginDate.ToString("yyyy-MM-dd"));
                                                                    if (itemSeasons.EndDate != null && itemSeasons.BeginDate > DateTime.MinValue)
                                                                        hotelSeasons.EndDate = Convert.ToDateTime(itemSeasons.EndDate.ToString("yyyy-MM-dd"));

                                                                    insertedSeasonId = context.Insert(hotelSeasons).ToInt32();
                                                                }
                                                                else
                                                                {
                                                                    insertedSeasonId = controlSeason.Id;
                                                                }

                                                            }

                                                            var CategoryId = 0;
                                                            if (itemSeasons.FacilityCategories != null)
                                                            {
                                                                foreach (var itemFacilityCategories in itemSeasons.FacilityCategories)
                                                                {
                                                                    using (var ContextFaciltyCategories = new HotelFacilityCategoriesRepository())
                                                                    {
                                                                        if (ContextFaciltyCategories != null)
                                                                        {
                                                                            if (itemFacilityCategories != null && itemFacilityCategories.Name != null)
                                                                            {
                                                                                var controlFacilityCategory = ContextFaciltyCategories.GetByName(itemFacilityCategories.Name).FirstOrDefault();
                                                                                if (controlFacilityCategory == null)
                                                                                {
                                                                                    CategoryId = ContextFaciltyCategories.Insert(new HotelFacilityCategories()
                                                                                    {
                                                                                        ApiId = (int)ApiType.Paximum,
                                                                                        CreatedBy = 1,
                                                                                        UpdatedBy = 1,
                                                                                        LanguageId = itemCountry.DefaultLanguageId,
                                                                                        CreatedDate = DateTime.Now,
                                                                                        UpdatedDate = DateTime.Now,
                                                                                        SystemId = itemFacilityCategories?.Id?.ToInt32(),
                                                                                        Name = itemFacilityCategories?.Name,
                                                                                        SeasonId = insertedSeasonId,
                                                                                        Type = 2
                                                                                    }).ToInt32();
                                                                                }
                                                                                else
                                                                                    CategoryId = controlFacilityCategory.Id;
                                                                            }
                                                                        }
                                                                    }
                                                                    if (itemFacilityCategories.Facilities != null && itemFacilityCategories.Facilities.Any())
                                                                    {

                                                                        foreach (var itemFacilities in itemFacilityCategories.Facilities)
                                                                        {
                                                                            using (var contextFacilitiesRepository = new HotelFacilitiesRepository())
                                                                            {

                                                                                var controlFacility = contextFacilitiesRepository.GetByName(itemFacilities.Name).Where(a => a.FacilityCategoryId == CategoryId && a.IsPriced == itemFacilities.IsPriced).FirstOrDefault();
                                                                                if (controlFacility == null)
                                                                                {
                                                                                    contextFacilitiesRepository.Insert(new HotelFacilities()
                                                                                    {

                                                                                        ApiId = (int)ApiType.Paximum,
                                                                                        CreatedBy = 1,
                                                                                        UpdatedBy = 1,
                                                                                        LanguageId = itemCountry.DefaultLanguageId,
                                                                                        CreatedDate = DateTime.Now,
                                                                                        UpdatedDate = DateTime.Now,
                                                                                        SystemId = itemFacilities?.Id?.ToString(),
                                                                                        Name = itemFacilities?.Name,
                                                                                        IsPriced = itemFacilities?.IsPriced,
                                                                                        FacilityCategoryId = CategoryId.ToInt32(),
                                                                                        Highlighted = itemFacilities.Highlighted,
                                                                                        HotelId = hotel.Id.ToInt32(),
                                                                                        Note = itemFacilities.Note,
                                                                                        Unit = itemFacilities.Unit,
                                                                                        SesonId = insertedSeasonId,
                                                                                        Type = 2
                                                                                    });


                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            if (itemSeasons.TextCategories != null)
                                                            {
                                                                foreach (var itemTextCategories in itemSeasons.TextCategories)
                                                                {
                                                                    var textCategoryId = 0;
                                                                    if (itemTextCategories.Code != null)
                                                                    {
                                                                        using (var textCategoryCotnext = new HotelTextCategoriesRepository())
                                                                        {
                                                                            textCategoryId = textCategoryCotnext.Insert(new HotelTextCategories()
                                                                            {
                                                                                Code = itemTextCategories.Code,
                                                                                Name = itemTextCategories.Name,
                                                                                ApiId = (int)ApiType.Paximum,
                                                                                CreatedBy = 1,
                                                                                UpdatedBy = 1,
                                                                                LanguageId = itemCountry.DefaultLanguageId,
                                                                                CreatedDate = DateTime.Now,
                                                                                UpdatedDate = DateTime.Now,
                                                                                Type = 2,
                                                                                SystemId = hotel.Id.ToInt32(),
                                                                                SeasonId = itemSeasons.Id

                                                                            }).ToInt32();
                                                                        }
                                                                    }


                                                                    if (itemSeasons.MediaFiles != null)
                                                                    {
                                                                        foreach (var itemMediaFiles in itemSeasons.MediaFiles)
                                                                        {
                                                                            using (var mediaFilesReps = new HotelSeasonMediaFilesRepository())
                                                                            {
                                                                                if (mediaFilesReps != null)
                                                                                {
                                                                                    mediaFilesReps.Insert(new HotelSeasonMediaFiles()
                                                                                    {

                                                                                        ApiId = (int)ApiType.Paximum,
                                                                                        CreatedBy = 1,
                                                                                        UpdatedBy = 1,
                                                                                        LanguageId = itemCountry.DefaultLanguageId,
                                                                                        CreatedDate = DateTime.Now,
                                                                                        UpdatedDate = DateTime.Now,
                                                                                        Url = itemMediaFiles.Url,
                                                                                        UrlFull = itemMediaFiles.UrlFull,
                                                                                        FileType = itemMediaFiles.FileType,
                                                                                        SeasonId = itemSeasons.Id,
                                                                                        Type = 2,
                                                                                        SystemId = hotel.Id

                                                                                    });
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                }
                                                            }


                                                        }
                                                    }
                                                    #endregion

                                                    #region Rooms
                                                    var hotelRooms = HotelProduct.Body.Hotel.Rooms;

                                                    if (hotelRooms != null)
                                                    {
                                                        HotelRoomsRepository _hotelRooms = new HotelRoomsRepository();

                                                        foreach (var itemRooms in hotelRooms)
                                                        {
                                                            _hotelRooms.Insert(new HotelRooms()
                                                            {
                                                                ApiId = (int)ApiType.Paximum,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                LanguageId = itemCountry.DefaultLanguageId,
                                                                CreatedDate = DateTime.Now,
                                                                UpdatedDate = DateTime.Now,
                                                                BoardName = itemRooms.BoardName,
                                                                BoardId = itemRooms.BoardId,
                                                                Code = itemRooms.Code,
                                                                HotelId = itemRooms.HotelId,
                                                                Id = itemRooms.Id.ToInt32(),
                                                                Name = itemRooms.Name,
                                                                RoomId = itemRooms.RoomId,
                                                                RoomInfoId = itemRooms.RoomInfoId,
                                                                RoomName = itemRooms.RoomName,
                                                                SystemId = itemRooms.SystemId,
                                                                Type = (int)ApiResponseTypes.Rooms
                                                            });
                                                        }
                                                    }

                                                    #endregion
                                                    #endregion

                                                }

                                            }
                                        }
                                        catch  
                                        {
                                             
                                        }
                                    }
                                }
                            }

                        }

                    } 
                    #endregion
                }
            }
        }
    }
}