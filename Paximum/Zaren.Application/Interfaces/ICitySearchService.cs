﻿using Zaren.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zaren.Application.Services.Interfaces
{
    public interface ICitySearchService
    {
        string tokne { get; set; }

        Task<List<CityObject>> Search(string querys);
        Task<List<HotelObject>> CityHotelSearch(string querys);
        Task<List<CityObject>> SearchAll();

    }
}