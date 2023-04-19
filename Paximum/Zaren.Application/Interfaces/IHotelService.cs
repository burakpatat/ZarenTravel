
using Zaren.Domain.Hotel;
using Zaren.Shared.HotelModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zaren.Application.Services.Interfaces
{
    public interface IHotelService
    {
        string tokne { get; set; }

        Task<HotelDetailDTO> GetDetails(string querys, int adultnum, string checkinstr);
        Task<HotelDetailDTO> GetOfferHotelDetails(string querys,string offerId, string currency, bool getProductInfo, int adultnum, string checkinstr);
        Task<List<HotelDetailDTO>> GetAllDetails(AllHotelQueryDTO qu);
        Task<HotelDetailGetOffersDTO> GetOfferHotelDetail(List<string> offerId, string currency = "EUR", bool getProductInfo = true);

    }
}