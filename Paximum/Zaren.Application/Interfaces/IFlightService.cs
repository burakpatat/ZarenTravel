using Zaren.Domain;
using Zaren.Shared.HotelModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zaren.Shared.FlightModels;
using Zaren.Application.Services;

namespace Zaren.Application.Interfaces
{
    public interface IFlightService
    {
        string tokne { get; set; }

        Task<FlightDetailDTO> GetDetails(string querys, int adultnum, string checkinstr);
        Task<FlightDetailDTO> GetOfferHotelDetails(string querys, string offerId, string currency, bool getProductInfo, int adultnum, string checkinstr);
        Task<List<FlightDetailDTO>> GetFlightList(AllFlightQueryDTO qu);
        Task<List<CityFlight>> SearchFlightsCity(string cityname);
    }
}
