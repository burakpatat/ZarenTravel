using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Zaren.Application.Models;
using Zaren.Application.Services.Interfaces;
using Zaren.Data;
using Zaren.Domain;
using Zaren.Domain.Hotel;
using Zaren.Shared.HotelModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Zaren.Application.Services
{
    public class HotelService : IHotelService
    {

        public readonly IUnitOfWork _unitofwork;
        public readonly IEmailService _emailService;
        public string tokne { get; set; }
        private readonly ILogger<UsersService> _logger;
        public readonly IAuthenticationService _authenticationService;
        public HotelService(IUnitOfWork unitofwork, IEmailService emailservice,
            ILogger<UsersService> logger, IAuthenticationService authenticationService)
        {
            _unitofwork = unitofwork;
            _emailService = emailservice;
            _logger = logger;
            _authenticationService = authenticationService;

        }
        //for get /pricesearch
        public async Task<HotelDetailDTO> GetDetails(string querys, int adultnum, string checkinstr)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            RootQ searchobj = new RootQ();

            searchobj.Products.Add(querys);
            searchobj.roomCriteria[0].adult = adultnum;
            searchobj.checkIn = checkinstr;
            searchobj.getOnlyBestOffers = false;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            var fileName = DateTime.Now.Ticks;
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            HotelDetailDTO t = new HotelDetailDTO();
            Hotel hotelobj = new Hotel();
            if (obj.body == null)
            {
                return null;
            }
            hotelobj = obj.body.hotels[0];
            t.name = hotelobj.name;
            t.description = hotelobj.description;
            t.price = hotelobj.price;
            t.rating = Math.Round(hotelobj.rating, 1);
            t.rooms = hotelobj.offers[0].rooms;
            t.locationName = hotelobj.location.name;
            if (hotelobj.offers[0].cancellationPolicies != null)
            {
                t.cancellationDueDate = hotelobj.offers[0].cancellationPolicies[0].dueDate;
                t.cancellationPrice = hotelobj.offers[0].cancellationPolicies[0].price.amount;
                t.cancellationCurrency = hotelobj.offers[0].cancellationPolicies[0].price.currency;
            }
            t.offerId = hotelobj.offers[0].offerId;
            t.offerCheckIn = hotelobj.offers[0].checkIn;
            t.address = hotelobj.offers[0].adress;
            t.hotelCategory = hotelobj.hotelCategory;
            t.thumbnail = hotelobj.thumbnailFull;
            t.travellernum = hotelobj.offers[0].rooms[0].travellers.Count;
            t.facilities = hotelobj.facilities;
            t.thumbnailFull = hotelobj.thumbnailFull;
            return t;
        }
        public async Task<List<HotelDetailDTO>> GetAllDetails(AllHotelQueryDTO qu)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }

            EarlyRoot searchobj = new EarlyRoot();
            var st = new { id = qu.Id, type = 2 };
            searchobj.roomCriteria[0].adult = qu.NumberOfTravellers;
            searchobj.arrivalLocations[0] = st;
            searchobj.checkIn = qu.checkIn.ToString("yyyy-MM-dd");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            var fileName = DateTime.Now.Ticks;
            //if (!File.Exists(@"C:\\Users\\muslu\\OneDrive\\Masaüstü\\json\\" + fileName + ".json"))
            //    using (File.Create(@"C:\\Users\\muslu\\OneDrive\\Masaüstü\\json\\" + fileName + ".json")) ;
            //File.WriteAllText(@"C:\\Users\\muslu\\OneDrive\\Masaüstü\\json\\" + fileName + ".json", contents);
            GetDetailsResponse obj = JsonConvert.DeserializeObject<GetDetailsResponse>(contents);
            if (obj.body == null)
            {
                return null;
            }
            List<HotelDetailDTO> tt = new List<HotelDetailDTO>();
            List<Hotel> hotelobj = new List<Hotel>();
            hotelobj = obj.body.hotels;
            for (int i = 0; i < hotelobj.Count; i++)
            {
                HotelDetailDTO t = new HotelDetailDTO
                {
                    HotelId = hotelobj[i].id,
                    name = hotelobj[i].name,
                    description = hotelobj[i].description,
                    price = hotelobj[i].price,
                    rating = Math.Round(hotelobj[i].rating, 1),
                    rooms = hotelobj[i].offers[0].rooms,
                    themes = hotelobj[i].offers[0].themes,
                    stars = hotelobj[i].stars,
                    locationName = hotelobj[i].location.name
                };
                if (hotelobj[i].offers[0].cancellationPolicies != null && hotelobj[i].offers[0].cancellationPolicies.Any() && hotelobj[i].offers[0].cancellationPolicies[0] != null)
                {
                    t.cancellationDueDate = hotelobj[i].offers[0].cancellationPolicies[0].dueDate;
                    t.cancellationPrice = hotelobj[i].offers[0].cancellationPolicies[0].price.amount;
                    t.cancellationCurrency = hotelobj[i].offers[0].cancellationPolicies[0].price.currency;
                }
                t.themes = hotelobj[i].themes;
                t.offerId = hotelobj[i].offers[0].offerId;
                t.offerCheckIn = hotelobj[i].offers[0].checkIn;
                t.hotelCategory = hotelobj[i].hotelCategory;
                t.thumbnail = hotelobj[i].thumbnailFull;
                t.travellernum = hotelobj[i].offers[0].rooms[0].travellers.Count;
                t.price = hotelobj[i].offers[0].price;
                t.facilities = obj.body.hotels[0].facilities;
                t.mediaFiles = obj.body.hotels[0].mediaFiles;
                t.address = obj.body.hotels[i].address;
                tt.Add(t);
            }
            return tt;
        }
        public async Task<HotelDetailGetOffersDTO> GetOfferHotelDetail(List<string> offerId, string currency = "EUR", bool getProductInfo = true)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            GetOfferHotelDetailRequest searchobj = new GetOfferHotelDetailRequest();

            searchobj.offerIds = offerId;
            searchobj.currency = currency;
            searchobj.getProductInfo = getProductInfo;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getofferdetails", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            var fileName = DateTime.Now.Ticks;
            Zaren.Domain.Hotel.getoffersDetails.Root obj = JsonConvert.DeserializeObject<Zaren.Domain.Hotel.getoffersDetails.Root>(contents);
            HotelDetailGetOffersDTO t = new HotelDetailGetOffersDTO();
            Zaren.Domain.Hotel.getoffersDetails.Hotel hotelobj = new Zaren.Domain.Hotel.getoffersDetails.Hotel();
            if (obj.body == null)
            {
                return null;
            }

            hotelobj = obj.body.offerDetails[0].hotels[0];
            t.name = hotelobj.name;
            t.description = hotelobj.description;
            t.price = hotelobj.price;
            t.rating = Math.Round(hotelobj.rating, 1);
            t.stars=hotelobj.stars;
            t.rooms = hotelobj.rooms;
            t.locationName = hotelobj.location.name;
            if (hotelobj.offers[0].cancellationPolicies != null)
            {
                t.cancellationDueDate = hotelobj.offers[0].cancellationPolicies[0].dueDate;
                t.cancellationPrice = hotelobj.offers[0].cancellationPolicies[0].price.amount;
                t.cancellationCurrency = hotelobj.offers[0].cancellationPolicies[0].price.currency;
            }
            t.rooms = hotelobj.offers[0].rooms;
            t.offerId = hotelobj.offers[0].offerId;
            t.offerCheckIn = hotelobj.offers[0].checkIn;
            t.address = hotelobj.address;
            t.hotelCategory = hotelobj.hotelCategory;
            t.thumbnail = hotelobj.thumbnailFull;
            t.travellernum = hotelobj.offers[0].rooms[0].travellers.Count;
            t.price = obj.body.offerDetails[0].price;
            t.thumbnailFull = hotelobj.thumbnailFull;
            t.mediaFiles = hotelobj.seasons[0].mediaFiles;
            if (hotelobj.seasons[0].facilityCategories!=null)
            {
                t.facilities = hotelobj.seasons[0].facilityCategories[0].facilities;
            }
            return t;
        }

        //GetDetailsResponse obj = JsonConvert.DeserializeObject<GetDetailsResponse>(contents);
        //HotelDetailDTO t = new HotelDetailDTO();

        //if (obj.body == null)
        //{
        //    return null;
        //}
        //var hotelobj = obj.body.offerDetails[0].hotels[0];
        //var body = obj.body.offerDetails[0];
        //t.name = hotelobj.name;
        //t.description = body.hotels[0].description.text;
        //var _price = new Domain.Hotel.Price();
        //_price.amount = body.price.amount;
        //_price.currency = body.price.currency;
        //t.price = _price;
        //t.rating = Math.Round(hotelobj.rating, 1);
        //t.rooms = new List<Room>();
        //t.rooms.Add(new Domain.Hotel.Room()
        //{
        //    boardGroups = hotelobj.offers[0].rooms
        //});

        //t.locationName = hotelobj.location.name;
        //if (hotelobj.offers[0].cancellationPolicies != null)
        //{
        //    t.cancellationDueDate = hotelobj.offers[0].cancellationPolicies[0].dueDate;
        //    t.cancellationPrice = hotelobj.offers[0].cancellationPolicies[0].price.amount;
        //    t.cancellationCurrency = hotelobj.offers[0].cancellationPolicies[0].price.currency;
        //}
        //t.offerId = hotelobj.offers[0].offerId;
        //t.offerCheckIn = hotelobj.offers[0].checkIn;
        //t.address = hotelobj.address;
        //t.hotelCategory = hotelobj.hotelCategory;
        //t.thumbnail = hotelobj.thumbnailFull;
        //t.travellernum = hotelobj.offers[0].rooms[0].travellers.Count;
        //t.facilities = hotelobj.facilities;
        //t.thumbnailFull = hotelobj.thumbnailFull;
        //return t;
        public async Task<HotelDetailDTO> GetOfferHotelDetails(string querys, string offerId, string currency, bool getProductInfo, int adultnum, string checkinstr)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            RootQ searchobj = new RootQ();
            searchobj.Products.Add(querys);
            searchobj.roomCriteria[0].adult = adultnum;
            searchobj.checkIn = checkinstr;
            searchobj.getOnlyBestOffers = false;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent);
            string contents = await req.Content.ReadAsStringAsync();
            var fileName = DateTime.Now.Ticks;
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            HotelDetailDTO t = new HotelDetailDTO();
            Hotel hotelobj = new Hotel();
            if (obj.body == null)
            {
                return null;
            }
            hotelobj = obj.body.hotels[0];

            t.name = hotelobj.name;
            t.description = hotelobj.description;
            t.price = hotelobj.offers[0].price;
            t.rating = Math.Round(hotelobj.rating, 1);
            t.rooms = hotelobj.offers[0].rooms;
            t.locationName = hotelobj.location.name;
            if (hotelobj.offers[0].cancellationPolicies != null)
            {
                t.cancellationDueDate = hotelobj.offers[0].cancellationPolicies[0].dueDate;
                t.cancellationPrice = hotelobj.offers[0].cancellationPolicies[0].price.amount;
                t.cancellationCurrency = hotelobj.offers[0].cancellationPolicies[0].price.currency;
            }
            t.offerId = hotelobj.offers[0].offerId;
            t.offerCheckIn = hotelobj.offers[0].checkIn;
            t.address = hotelobj.offers[0].adress;
            t.hotelCategory = hotelobj.hotelCategory;
            t.thumbnail = hotelobj.thumbnailFull;
            t.travellernum = hotelobj.offers[0].rooms[0].travellers.Count;
            t.facilities = hotelobj.facilities;
            t.thumbnailFull = hotelobj.thumbnailFull;
            return t;
        }

    }

    public class GetOfferHotelDetailRequest
    {
        public List<string> offerIds { get; set; }
        public string currency { get; set; }
        public bool getProductInfo { get; set; }
    }


}
