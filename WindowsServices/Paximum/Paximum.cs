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
using Paximum.Response.Offers;
using System.Web.Routing;

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

                        var list = new PossibleQueryRepository().GetAll();
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
                            var contentAutocomplete = req.Result.Content.ReadAsStringAsync().Result;
                            GetArrivalAutocompleteResponse GetArrivalAutocompleteResponse = JsonConvert.DeserializeObject<GetArrivalAutocompleteResponse>(contentAutocomplete);
                            GetOfferDetailsResponse _GetOfferDetailsResponse = new GetOfferDetailsResponse();


                            foreach (var itemAutoComplete in GetArrivalAutocompleteResponse.Body.Items)
                            {

                                foreach (var itemCountry in new CountryRepository().GetAll().Where(a => a.Id == 212).ToList())
                                {

                                    #region AutoCompleteData
                                    if (itemAutoComplete.City != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(itemAutoComplete?.City?.Name).Where(a => a.Name == itemAutoComplete.City?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = itemAutoComplete.City?.Id,
                                                Name = itemAutoComplete.City?.Name,
                                                SystemType = itemAutoComplete.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.City,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }
                                    }
                                    if (itemAutoComplete.State != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(itemAutoComplete?.State?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = itemAutoComplete.State?.Id,
                                                Name = itemAutoComplete.State?.Name,
                                                SystemType = itemAutoComplete.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.State,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }

                                    }
                                    if (itemAutoComplete.Country != null)
                                    {
                                        var controlItem = autoCompleteRepository.GetByName(itemAutoComplete?.Country?.Name).Where(a => a.Name == itemAutoComplete?.Country?.Name).FirstOrDefault();
                                        if (controlItem == null)
                                        {
                                            autoCompleteRepository.Insert(new AutoCompletes()
                                            {
                                                ApiId = (int)ApiType.Paximum,
                                                SystemId = itemAutoComplete.Country?.Id,
                                                Name = itemAutoComplete.Country?.Name,
                                                SystemType = itemAutoComplete.Type.ToString(),
                                                Type = (int)AutoCompleteTypes.Country,
                                                LanguageId = itemCountry.DefaultLanguageId
                                            });
                                        }
                                    }
                                    #endregion

                                    foreach (var currencyItem in currencyRepository.GetAll().Where(a => a.CurrencyCode == "TRY").ToList())
                                    {
                                        int i = 7;
                                        int year = 150;
                                        int adult = 1;

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
                                        Roomcriteria.ChildAges = new List<int>();
                                        Roomcriteria.ChildAges.Add(1);
                                        Roomcriteria.ChildAges.Add(7);
                                        priceSearchLocation.RoomCriteria.Add(Roomcriteria);

                                        priceSearchLocation.ArrivalLocations = new List<ArrivalLocation>();
                                        if (itemAutoComplete.GiataInfo == null)
                                        {
                                            priceSearchLocation.ArrivalLocations.Add(new ArrivalLocation()
                                            {
                                                Id = itemAutoComplete.City.Id,
                                                Type = 2
                                            });
                                        }
                                        else
                                        {
                                            priceSearchLocation.ArrivalLocations.Add(new ArrivalLocation()
                                            {
                                                Id = itemAutoComplete.GiataInfo.HotelId,
                                                Type = itemAutoComplete.Type
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
                                            var contentsPricesearch = req.Result.Content.ReadAsStringAsync().Result;

                                            PriceSearchResponse PriceSearchobj = JsonConvert.DeserializeObject<PriceSearchResponse>(contentsPricesearch);
                                            var responseDate = DateTime.Now;
                                            var model = new ApiResults()
                                            {
                                                RequestData = content,
                                                ResponseData = contentsPricesearch,
                                                RequestDate = requestDate,
                                                ResponseDate = responseDate,
                                                Currency = priceSearchLocation.Currency,
                                                CheckIn = priceSearchLocation.CheckIn.ToString(),
                                                Nationality = "TR",
                                                ApiId = (int)ApiType.Paximum,
                                                IsSuccessfull = PriceSearchobj.header?.success,
                                                LocationId = itemAutoComplete.City?.Id.ToInt32(),
                                                Query = GetArrivalAutocomplete.Query + ":" + JsonConvert.SerializeObject(itemAutoComplete),
                                                ProductType = 2
                                            };

                                            using (var repo = new ApiResultsRepository())
                                            {
                                                var controlResp = repo.GetByLocationId(itemAutoComplete.City.Id.ToInt32()).FirstOrDefault();
                                                if (controlResp == null)
                                                    repo.Insert(model);
                                            }
                                            #endregion

                                            if (PriceSearchobj != null && PriceSearchobj.body != null && PriceSearchobj.body.hotels != null && PriceSearchobj.body.hotels.Any())
                                            {
                                                foreach (var hotelPriceSearch in PriceSearchobj.body.hotels)
                                                {


                                                    #region ProductInfo
                                                    GetProductInfoRequest getProductInfoRequest = new GetProductInfoRequest();
                                                    getProductInfoRequest.Culture = itemCulture.CountryCode;
                                                    getProductInfoRequest.Product = hotelPriceSearch.id;
                                                    getProductInfoRequest.ProductType = 2;
                                                    getProductInfoRequest.OwnerProvider = 2;
                                                    client = new HttpClient();

                                                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);

                                                    content = JsonConvert.SerializeObject(getProductInfoRequest);
                                                    buffer = Encoding.UTF8.GetBytes(content);
                                                    byteContent = new ByteArrayContent(buffer);
                                                    req = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getproductinfo", byteContent);
                                                    var contentsGetproductinfo = req.Result.Content.ReadAsStringAsync().Result;
                                                    HotelProductResponse HotelProduct = JsonConvert.DeserializeObject<HotelProductResponse>(contentsGetproductinfo);
                                                    var hotelGetproductinfo = HotelProduct.Body.Hotel;
                                                    int insertedSeasonId = 0;
                                                    int insertedOrSelectedHotelId = 0;
                                                    var insertedGiataInfosId = 0;

                                                    #region HotelCategory
                                                    var InsertedHotelCategoryID = 0;
                                                    if (hotelGetproductinfo.HotelCategory != null)
                                                    {
                                                        using (var HotelCategoriesRepository = new HotelCategoriesRepository())
                                                        {
                                                            var isExistCategoryId = HotelCategoriesRepository.GetBySystemId(hotelGetproductinfo.HotelCategory.Id.ToInt32()).Where(a => a.Name == hotelGetproductinfo.HotelCategory.Name).FirstOrDefault();
                                                            if (isExistCategoryId == null)
                                                            {
                                                                var hotelcategoryModel = new Model.Concrete.HotelCategories()
                                                                {
                                                                    Name = hotelGetproductinfo?.HotelCategory?.Name,
                                                                    Code = hotelGetproductinfo?.HotelCategory?.Code,
                                                                    SystemId = hotelGetproductinfo?.HotelCategory?.Id?.ToInt32(),
                                                                    CreatedDate = DateTime.Now,
                                                                    UpdatedDate = DateTime.Now,
                                                                };
                                                                InsertedHotelCategoryID = HotelCategoriesRepository.Insert(hotelcategoryModel).ToInt32();
                                                            }
                                                            else
                                                            {
                                                                var hotelcategoryModel = new Model.Concrete.HotelCategories()
                                                                {
                                                                    Id = isExistCategoryId.Id,
                                                                    Name = hotelGetproductinfo?.HotelCategory?.Name,
                                                                    Code = hotelGetproductinfo?.HotelCategory?.Code,
                                                                    SystemId = hotelGetproductinfo?.HotelCategory?.Id?.ToInt32(),
                                                                    CreatedDate = DateTime.Now,
                                                                    UpdatedDate = DateTime.Now,
                                                                };
                                                                HotelCategoriesRepository.Update(hotelcategoryModel).ToInt32();
                                                            }
                                                        }
                                                    }
                                                    #endregion


                                                    #region Hotel 
                                                    using (var ContextGiataInfos = new GiataInfosRepository())
                                                    {
                                                        var existGiataInfos = ContextGiataInfos.GetByHotelId(hotelPriceSearch.giataInfo?.hotelId.ToInt32()).Where(a => a.DestinationId == hotelPriceSearch.giataInfo?.destinationId.ToInt32()).FirstOrDefault();
                                                        if (existGiataInfos == null)
                                                        {
                                                            var giatainfosModel = new GiataInfos()
                                                            {
                                                                HotelId = hotelPriceSearch.giataInfo?.hotelId.ToInt32(),
                                                                DestinationId = hotelPriceSearch.giataInfo?.destinationId.ToInt32(),
                                                                SystemId = hotelPriceSearch.giataInfo?.hotelId.ToInt32(),
                                                                UpdatedDate = DateTime.Now,
                                                            };
                                                            insertedGiataInfosId = ContextGiataInfos.Insert(giatainfosModel).ToInt32();
                                                        }
                                                        else
                                                        {
                                                            insertedGiataInfosId = existGiataInfos.Id;
                                                        }
                                                    }
                                                    using (var context = new HotelsRepository())
                                                    {
                                                        var controlHotelsGiadata = context.GetByGiataInfoId(insertedGiataInfosId).Where(a=> a.HotelId == hotelPriceSearch.id.ToInt32()).FirstOrDefault();
                                                        if (controlHotelsGiadata == null)
                                                        {
                                                            var hotelModel = new Hotels()
                                                            {
                                                                SystemId = hotelPriceSearch.id.ToString(),
                                                                Name = hotelGetproductinfo.Name,
                                                                ApiId = (int)ApiType.Paximum,
                                                                CreatedBy = 1,
                                                                UpdatedBy = 1,
                                                                GiataInfoId = insertedGiataInfosId,
                                                                FaxNumber = hotelGetproductinfo.FaxNumber,
                                                                CreatedDate = DateTime.Now,
                                                                HomePage = hotelGetproductinfo.HomePage,
                                                                PhoneNumber = hotelGetproductinfo.PhoneNumber,
                                                                Provider = hotelGetproductinfo.Provider,
                                                                HotelId = hotelPriceSearch.id?.ToInt32(),
                                                                Thumbnail = hotelGetproductinfo.Thumbnail,
                                                                ThumbnailFull = hotelGetproductinfo.ThumbnailFull,
                                                                Address = hotelPriceSearch.address,
                                                                Description = hotelPriceSearch.description?.text,
                                                                CountryId = hotelPriceSearch.country?.id?.ToInt32(),
                                                                HotelCategoryId = InsertedHotelCategoryID,
                                                                LanguageId = itemCountry.DefaultLanguageId,
                                                                Latitude = hotelPriceSearch.geolocation.latitude.ToFloat(),
                                                                Longtitude = hotelPriceSearch.geolocation.longitude.ToFloat(),
                                                                UpdatedDate = DateTime.Now
                                                            };
                                                            insertedOrSelectedHotelId = context.Insert(hotelModel).ToInt32();

                                                            if (hotelGetproductinfo.Name != null)
                                                            {
                                                                var controlItem = autoCompleteRepository.GetByName(hotelGetproductinfo.Name).FirstOrDefault();
                                                                if (controlItem == null)
                                                                {
                                                                    autoCompleteRepository.Insert(new AutoCompletes()
                                                                    {
                                                                        ApiId = (int)ApiType.Paximum,
                                                                        SystemId = hotelPriceSearch.id,
                                                                        Name = hotelGetproductinfo.Name,
                                                                        SystemType = itemAutoComplete.Type.ToString(),
                                                                        Type = (int)AutoCompleteTypes.Hotel,
                                                                        LanguageId = itemCountry.DefaultLanguageId
                                                                    });
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            var hotelupdateModel = new Hotels()
                                                            {
                                                                Id = controlHotelsGiadata.Id,
                                                                SystemId = hotelPriceSearch.id.ToString(),
                                                                Name = hotelGetproductinfo.Name,
                                                                ApiId = (int)ApiType.Paximum,
                                                                CreatedBy = controlHotelsGiadata.CreatedBy,
                                                                UpdatedBy = 1,
                                                                GiataInfoId = insertedGiataInfosId,
                                                                FaxNumber = hotelGetproductinfo.FaxNumber,
                                                                CreatedDate = controlHotelsGiadata.CreatedDate,
                                                                HomePage = hotelGetproductinfo.HomePage,
                                                                PhoneNumber = hotelGetproductinfo.PhoneNumber,
                                                                Provider = hotelGetproductinfo.Provider,
                                                                HotelId = hotelPriceSearch?.id?.ToInt32(),
                                                                Thumbnail = hotelGetproductinfo.Thumbnail,
                                                                ThumbnailFull = hotelGetproductinfo.ThumbnailFull,
                                                                Address = hotelPriceSearch.address,
                                                                Description = hotelPriceSearch.description?.text,
                                                                CountryId = hotelPriceSearch.country?.id?.ToInt32(),
                                                                HotelCategoryId = InsertedHotelCategoryID,
                                                                LanguageId = itemCountry.DefaultLanguageId,
                                                                Latitude = hotelPriceSearch.geolocation.latitude.ToFloat(),
                                                                Longtitude = hotelPriceSearch.geolocation.longitude.ToFloat(),
                                                                UpdatedDate = DateTime.Now
                                                            };
                                                            context.Update(hotelupdateModel);

                                                            insertedOrSelectedHotelId = controlHotelsGiadata.Id;
                                                        }
                                                    }
                                                    #endregion

                                                    #region Seasons

                                                    if (hotelGetproductinfo.Seasons != null)
                                                    {
                                                        foreach (var itemSeasons in hotelGetproductinfo.Seasons)
                                                        {
                                                            using (var context = new HotelSeasonsRepository())
                                                            {
                                                                var controlSeason = context.GetByName(itemSeasons.Name);
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
                                                                        UpdatedDate = DateTime.Now,
                                                                        BeginDate = itemSeasons.BeginDate,
                                                                        EndDate = itemSeasons.EndDate
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

                                                                var controlSelectedSeason = context.GetByHotelIdAndSeasonId(insertedOrSelectedHotelId, insertedSeasonId);
                                                                if (controlSelectedSeason == null)
                                                                {
                                                                    context.SelectedInsert(new HotelSelectedSeasons()
                                                                    {
                                                                        HotelId = insertedOrSelectedHotelId,
                                                                        SeasonId = insertedSeasonId
                                                                    });
                                                                }

                                                            }


                                                            var CategoryId = 0;
                                                            if (itemSeasons.FacilityCategories != null)
                                                            {
                                                                foreach (var itemFacilityCategories in itemSeasons.FacilityCategories)
                                                                {
                                                                    using (var ContextFaciltyCategories = new FacilityCategoriesRepository())
                                                                    {
                                                                        if (ContextFaciltyCategories == null)
                                                                        {
                                                                            if (itemFacilityCategories != null && itemFacilityCategories.Name != null)
                                                                            {
                                                                                var controlFacilityCategory = ContextFaciltyCategories.GetByName(itemFacilityCategories.Name).FirstOrDefault();
                                                                                if (controlFacilityCategory == null)
                                                                                {
                                                                                    CategoryId = ContextFaciltyCategories.Insert(new FacilityCategories()
                                                                                    {
                                                                                        ApiId = (int)ApiType.Paximum,
                                                                                        CreatedBy = 1,
                                                                                        UpdatedBy = 1,
                                                                                        LanguageId = itemCountry.DefaultLanguageId,
                                                                                        CreatedDate = DateTime.Now,
                                                                                        UpdatedDate = DateTime.Now,
                                                                                        SystemId = itemFacilityCategories?.Id,
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
                                                                            using (var contextFacilitiesRepository = new FacilitiesRepository())
                                                                            {

                                                                                var controlFacility = contextFacilitiesRepository.GetByName(itemFacilities.Name).Where(a => a.FacilityCategoryId == CategoryId && a.IsPriced == itemFacilities.IsPriced).FirstOrDefault();
                                                                                if (controlFacility == null)
                                                                                {
                                                                                    contextFacilitiesRepository.Insert(new Facilities()
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
                                                                                        HotelId = insertedOrSelectedHotelId,
                                                                                        Note = itemFacilities.Note,
                                                                                        Unit = itemFacilities.Unit,
                                                                                        SeasonId = insertedSeasonId,
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
                                                                    if (itemTextCategories.Code == null)
                                                                    {
                                                                        using (var textCategoryCotnext = new TextCategoriesRepository())
                                                                        {
                                                                            textCategoryId = textCategoryCotnext.Insert(new TextCategories()
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
                                                                                SystemId = hotelGetproductinfo.Id,
                                                                                SeasonId = insertedSeasonId

                                                                            }).ToInt32();
                                                                        }
                                                                    }


                                                                    if (itemSeasons.MediaFiles != null)
                                                                    {
                                                                        foreach (var itemMediaFiles in itemSeasons.MediaFiles)
                                                                        {
                                                                            using (var mediaFilesReps = new MediaFilesRepository())
                                                                            {
                                                                                if (mediaFilesReps == null)
                                                                                {
                                                                                    mediaFilesReps.Insert(new MediaFiles()
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
                                                                                        SystemId = hotelGetproductinfo.Id.ToInt32()

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

                                                    var hotelRoomsInsertedId = 0;

                                                    foreach (var itemRoom in PriceSearchobj.body.hotels)
                                                    {
                                                        foreach (var itemRoomOffers in itemRoom.offers)
                                                        {

                                                            var _HotelRooms = itemRoomOffers.rooms;

                                                            OffersRepository _hotelRoomsOffersRep = new OffersRepository();

                                                            var ControlSytemIdandOfferId = _hotelRoomsOffersRep.GetBySystemId(hotelGetproductinfo.Id.ToInt32()).FirstOrDefault();

                                                            if (ControlSytemIdandOfferId == null)
                                                            {
                                                                hotelRoomsInsertedId = _hotelRoomsOffersRep.Insert(new Model.Concrete.Offers()
                                                                {
                                                                    CheckIn = itemRoomOffers.checkIn,
                                                                    IsAvailable = itemRoomOffers.isAvailable,
                                                                    IsRefundable = itemRoomOffers.isRefundable,
                                                                    Night = itemRoomOffers.night,
                                                                    OfferId = itemRoomOffers.offerId,
                                                                    OwnOffer = itemRoomOffers.ownOffer,
                                                                    PriceAmount = itemRoomOffers.price.amount,
                                                                    PriceCurrency = itemRoomOffers.price.currency,
                                                                    SystemId = hotelGetproductinfo.Id.ToInt32()

                                                                }).ToInt32();
                                                            }
                                                            else
                                                            {
                                                                _hotelRoomsOffersRep.Update(new Model.Concrete.Offers()
                                                                {
                                                                    Id = ControlSytemIdandOfferId.Id,
                                                                    CheckIn = itemRoomOffers.checkIn,
                                                                    IsAvailable = itemRoomOffers.isAvailable,
                                                                    IsRefundable = itemRoomOffers.isRefundable,
                                                                    Night = itemRoomOffers.night,
                                                                    OfferId = itemRoomOffers.offerId,
                                                                    OwnOffer = itemRoomOffers.ownOffer,
                                                                    PriceAmount = itemRoomOffers.price.amount,
                                                                    PriceCurrency = itemRoomOffers.price.currency,
                                                                    SystemId = hotelGetproductinfo.Id.ToInt32()

                                                                });
                                                            }



                                                            if (_HotelRooms != null)
                                                            {
                                                                RoomsRepository _hotelRooms = new RoomsRepository();
                                                                var insertedRoomId = 0;
                                                                var insertedPriceId = 0;

                                                                PricesRepository prices = new PricesRepository();
                                                                PriceBreakDownsRepository priceBreakDownsRepository = new PriceBreakDownsRepository();

                                                                foreach (var itemRooms in _HotelRooms)
                                                                {
                                                                    //price
                                                                    var controlPrice = prices.GetBySystemId(insertedRoomId.ToString()).FirstOrDefault();
                                                                    if (controlPrice == null)
                                                                    {
                                                                        insertedPriceId = prices.Insert(new Model.Concrete.Prices()
                                                                        {
                                                                            SystemId = insertedRoomId.ToString(),
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedDate = DateTime.Now,
                                                                            CreatedBy = 1,
                                                                            UpdatedBy = 1,
                                                                            LanguageId = itemCountry.DefaultLanguageId,
                                                                            Amount = (decimal)itemRoomOffers.price.amount,
                                                                        }).ToInt32();

                                                                        priceBreakDownsRepository.Insert(new Model.Concrete.PriceBreakDowns()
                                                                        {
                                                                            RoomNumber = itemRooms.roomId?.ToInt32(),
                                                                            SystemId = insertedRoomId.ToString(),

                                                                        });
                                                                    }
                                                                    else
                                                                    {

                                                                        prices.Update(new Model.Concrete.Prices()
                                                                        {
                                                                            SystemId = insertedRoomId.ToString(),
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedDate = DateTime.Now,
                                                                            CreatedBy = 1,
                                                                            UpdatedBy = 1,
                                                                            LanguageId = itemCountry.DefaultLanguageId,
                                                                            Amount = (decimal)itemRoomOffers.price.amount
                                                                        });

                                                                        priceBreakDownsRepository.Update(new Model.Concrete.PriceBreakDowns()
                                                                        {
                                                                            RoomNumber = itemRooms.roomId?.ToInt32(),
                                                                            SystemId = insertedRoomId.ToString(),

                                                                        });
                                                                    }

                                                                    //rooms
                                                                    var isRoomExistForHotelItem = _hotelRooms.GetByHotelIdandBoardName(hotelGetproductinfo.Id.ToInt32(), itemRooms.boardName).FirstOrDefault();

                                                                    if (isRoomExistForHotelItem == null)
                                                                    {
                                                                       _hotelRooms.Insert(new Model.Concrete.Rooms()
                                                                        {
                                                                            ApiId = (int)ApiType.Paximum,
                                                                            CreatedBy = 1,
                                                                            UpdatedBy = 1,
                                                                            CreatedDate = DateTime.Now,
                                                                            UpdatedDate = DateTime.Now,
                                                                            BoardName = itemRooms.boardName,
                                                                            HotelId = hotelGetproductinfo.Id.ToInt32(),
                                                                            Name = itemRooms.roomName,
                                                                            SystemId = itemRooms.roomId,
                                                                            Type = (int)ApiResponseTypes.Rooms,
                                                                            OfferId = itemRoomOffers.offerId,
                                                                            PriceId = insertedPriceId,
                                                                        }); 
                                                                    }
                                                                    else
                                                                    {
                                                                        _hotelRooms.Update(new Model.Concrete.Rooms()
                                                                        {
                                                                            Id = isRoomExistForHotelItem.Id,
                                                                            ApiId = (int)ApiType.Paximum,
                                                                            CreatedBy = isRoomExistForHotelItem.CreatedBy,
                                                                            UpdatedBy = 1,
                                                                            LanguageId = itemCountry.DefaultLanguageId,
                                                                            CreatedDate = isRoomExistForHotelItem.CreatedDate,
                                                                            UpdatedDate = DateTime.Now,
                                                                            BoardName = itemRooms.boardName,
                                                                            BoardId = itemRooms.boardId.ToInt32(),
                                                                            HotelId = hotelGetproductinfo.Id.ToInt32(),
                                                                            OfferId = itemRoomOffers.offerId,
                                                                            Name = itemRooms.roomName,
                                                                            SystemId = itemRooms.roomId,
                                                                            Type = (int)ApiResponseTypes.Rooms,
                                                                            PriceId = insertedPriceId,
                                                                        });
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }

                                                    #endregion
                                                    #endregion

                                                    #region Prices
                                                    try
                                                    {
                                                        foreach (var offerItem in hotelPriceSearch.offers)
                                                        {
                                                            GetOfferDetailRequest searchobj = new GetOfferDetailRequest();

                                                            searchobj.offerIds = new List<string>();
                                                            searchobj.offerIds.Add(offerItem?.offerId);
                                                            searchobj.currency = offerItem?.price?.currency;
                                                            searchobj.getProductInfo = true;
                                                            client = new HttpClient();
                                                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bodyData.Body.Token);
                                                            content = JsonConvert.SerializeObject(searchobj);
                                                            buffer = Encoding.UTF8.GetBytes(content);
                                                            byteContent = new ByteArrayContent(buffer);
                                                            var ressreq = client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getofferdetails", byteContent).Result;
                                                            var contentsGetofferdetails = ressreq.Content.ReadAsStringAsync().Result;
                                                            _GetOfferDetailsResponse = JsonConvert.DeserializeObject<GetOfferDetailsResponse>(contentsGetofferdetails);

                                                            foreach (var Offerdetails in _GetOfferDetailsResponse.body.offerDetails)
                                                            {
                                                                //Agency Commission
                                                                using (var _AgencyCommissions = new AgencyCommisionsRepository())
                                                                {
                                                                    if (Offerdetails.agencyCommission != null && Offerdetails.agencyCommission.amount != null && Offerdetails.agencyCommission.amount > 0)
                                                                    {
                                                                        var controlAgencyCommision = _AgencyCommissions.GetByPercents(Offerdetails.agencyCommission?.percent).FirstOrDefault();
                                                                        if (controlAgencyCommision == null)
                                                                        {
                                                                            _AgencyCommissions.Insert(new Model.Concrete.AgencyCommisions()
                                                                            {
                                                                                ApiId = (int)ApiType.Paximum,
                                                                                Amount = Offerdetails?.agencyCommission?.amount,
                                                                                Currency = Offerdetails?.agencyCommission?.currency,
                                                                                CreatedDate = DateTime.Now,
                                                                                UpdatedDate = DateTime.Now,
                                                                                SystemId = insertedOrSelectedHotelId,
                                                                                OfferId = hotelRoomsInsertedId,
                                                                            });
                                                                        }
                                                                        else
                                                                        {
                                                                            _AgencyCommissions.Update(new Model.Concrete.AgencyCommisions()
                                                                            {
                                                                                Id = controlAgencyCommision.Id,
                                                                                ApiId = (int)ApiType.Paximum,
                                                                                Amount = Offerdetails?.agencyCommission?.amount,
                                                                                Currency = Offerdetails?.agencyCommission?.currency,
                                                                                CreatedDate = DateTime.Now,
                                                                                UpdatedDate = DateTime.Now,
                                                                                SystemId = insertedOrSelectedHotelId,
                                                                                OfferId = hotelRoomsInsertedId,
                                                                            });
                                                                        } 
                                                                    }
                                                                }

                                                                ///store procedure yapılacak!!!!

                                                                using (var _PassengerAmountToPay = new PassengerAmountToPayRepository())
                                                                {

                                                                    if (Offerdetails.passengerAmountToPay == null)
                                                                    {
                                                                        _PassengerAmountToPay.Insert(new Model.Concrete.PassengerAmounts()
                                                                        {
                                                                            //SystemId = insertedOrSelectedHotelId.ToString(),
                                                                            ApiId = (int)ApiType.Paximum,
                                                                            Amount = (decimal)Offerdetails?.passengerAmountToPay?.amount,
                                                                            Currency = Offerdetails?.passengerAmountToPay?.currency,
                                                                            CurrencyId = currencyItem.Id,
                                                                            OfferId = hotelRoomsInsertedId,
                                                                        });
                                                                    }
                                                                }
                                                                using (var _AgencySupplementCommission = new AgencySupplementCommissionsRepository())
                                                                {
                                                                    if (Offerdetails.agencySupplementCommission == null)
                                                                    {
                                                                        _AgencySupplementCommission.Insert(new Model.Concrete.AgencySupplementCommissions()
                                                                        {
                                                                            //SystemId = insertedOrSelectedHotelId.ToString(),
                                                                            ApiId = (int)ApiType.Paximum,
                                                                            Amount = (decimal)Offerdetails?.agencySupplementCommission?.amount,
                                                                            Currency = Offerdetails?.agencySupplementCommission?.currency,
                                                                            CurrencyId = currencyItem.Id,
                                                                            OfferId = hotelRoomsInsertedId,
                                                                        });
                                                                    }
                                                                }

                                                                // Cancellation Policies

                                                                foreach (var _cancellationPoliciesList in Offerdetails.cancellationPolicies)
                                                                {
                                                                    using (var _CancellationPolicies = new CancellationPoliciesRepository())
                                                                    {
                                                                        if (Offerdetails.cancellationPolicies == null)
                                                                        {
                                                                            _CancellationPolicies.Insert(new Model.Concrete.CancellationPolicies()
                                                                            {
                                                                                ApiId = (int)ApiType.Paximum,
                                                                                Provider = _cancellationPoliciesList.provider,
                                                                                DueDate = _cancellationPoliciesList.dueDate,
                                                                                Amount = _cancellationPoliciesList.price.amount,
                                                                                Currency = _cancellationPoliciesList.price.currency,
                                                                                OfferId = hotelRoomsInsertedId,
                                                                            });
                                                                        }
                                                                    }
                                                                }

                                                            }
                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {

                                                        var e = ex.Message.ToString();
                                                    }
                                                    #endregion
                                                }

                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            var a = e;
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