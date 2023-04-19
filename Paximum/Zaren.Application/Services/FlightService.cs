using Microsoft.Extensions.Logging;
using Zaren.Application.Services.Interfaces;
using Zaren.Application.Services;
using Zaren.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zaren.Application.Interfaces;
using Zaren.Shared.FlightModels;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.Http.Headers;
using System.Net.Http;
using Zaren.Domain;
//using Zaren.Shared.FlightModels;
using Zaren.Shared.HotelModels;
using Zaren.Domain.Flights;

namespace Zaren.Application.Services
{
    public class FlightService : IFlightService
    {
        public readonly IUnitOfWork _unitofwork;
        public readonly IEmailService _emailService;
        public string tokne { get; set; }
        private readonly ILogger<UsersService> _logger;
        public readonly IAuthenticationService _authenticationService;
        public FlightService(IUnitOfWork unitofwork, IEmailService emailservice,
            ILogger<UsersService> logger, IAuthenticationService authenticationService)
        {
            _unitofwork = unitofwork;
            _emailService = emailservice;
            _logger = logger;
            _authenticationService = authenticationService;

        }
        public async Task<List<CityFlight>> SearchFlightsCity(string cityname)
        {
            try
            {
                if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            FlightSearchRequest searchobj = new FlightSearchRequest
            {
                ProductType = 3,
                ServiceType = "1",
                Culture = "en-US",
                Query = cityname
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getdepartureautocomplete", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            List<Item> items = obj.Body.items;
            List<CityFlight> citys = new List<CityFlight>();
            if (items.Count!=0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    CityFlight city = new CityFlight();
                    if (items[i].airport != null)
                    {
                        city.Id= items[i].airport.Id;
                        city.Name= items[i].airport.Name;
                       
                    }
                    else
                    {
                        city.Name = items[i].City.Name;
                        city.Id = items[i].City.Id;
                    }
                    if (!citys.Contains(city))
                    {
                        citys.Add(city);
                    }
                }
            }
            return citys;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<FlightDetailDTO>> GetFlightList(AllFlightQueryDTO qu)
        {
            try
            {
                if (tokne == null)
                {
                    tokne = await _authenticationService.Login();
                }
                FlightSearchRequest searchobj = new FlightSearchRequest
                {
                    ProductType = 3,
                    ServiceType = "1",
                    Culture = "en-US",
                    //Query = cityname
                };
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
                var content = JsonConvert.SerializeObject(searchobj);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getdepartureautocomplete", byteContent);
                var contents = await req.Content.ReadAsStringAsync();
                Root obj = JsonConvert.DeserializeObject<Root>(contents);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            throw new NotImplementedException();

        }

        public Task<FlightDetailDTO> GetDetails(string querys, int adultnum, string checkinstr)
        {
            throw new NotImplementedException();
        }

        public Task<FlightDetailDTO> GetOfferHotelDetails(string querys, string offerId, string currency, bool getProductInfo, int adultnum, string checkinstr)
        {
            throw new NotImplementedException();
        }
    }
}
