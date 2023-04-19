using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model.Concrete;
using Zaren.Application.Services;
using Zaren.Application.Services.Interfaces;
using Zaren.Data;
using Zaren.Domain;
using Zaren.Domain.City;
using Zaren.Domain.Hotel;
using Zaren.Shared.HotelModels;
using Zaren.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Zaren.Web.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Zaren.Web.Controllers
{
    public class HomeController : Controller
    {
        public SanProjectDBContext _context;
        public readonly IUnitOfWork _unitofwork;
        public readonly IUsersService _userservice;
        public readonly IAuthenticationService _authenticationservice;
        public readonly ICitySearchService _citysearchservice;
        public readonly IHotelService _hotelService;

        public HomeController(IUnitOfWork unitofwork, SanProjectDBContext context,
            IUsersService userservice, IAuthenticationService authenticationservice,
            ICitySearchService citysearchservice, IHotelService hotelService, IConfiguration configuration)
        {

            _unitofwork = unitofwork;
            _context = context;
            _userservice = userservice;
            _authenticationservice = authenticationservice;
            _citysearchservice = citysearchservice;
            _hotelService = hotelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {
            if ((cityName == null || cityName == "") || cityName.Length < 3)
            {
                return BadRequest("The City field requires at least 3 characters");
            }
            List<CityObject> t = await _citysearchservice.Search(cityName);
            return View(t);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
