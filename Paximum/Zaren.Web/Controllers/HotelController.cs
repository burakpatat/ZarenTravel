using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model.Concrete;
using Zaren.Application.Services.Interfaces;
using Zaren.Data;
using Zaren.Domain;
using Zaren.Shared.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zaren.Web.Controllers
{
    public class HotelController : Controller
    {
        public SanProjectDBContext _context;
        public readonly IUnitOfWork _unitofwork;
        public readonly IUsersService _userservice;
        public readonly IAuthenticationService _authenticationservice;
        public readonly ICitySearchService _citysearchservice;
        public IHotelService _hotelservice;
        public IConfiguration _configuration;
        public HotelController(IUnitOfWork unitofwork, SanProjectDBContext context,
          IUsersService userservice, IAuthenticationService authenticationservice,
          ICitySearchService citysearchservice, IHotelService hotelservice, IConfiguration configuration)
        {
            _configuration = configuration;
            _unitofwork = unitofwork;
            _context = context;
            _userservice = userservice;
            _authenticationservice = authenticationservice;
            _citysearchservice = citysearchservice;
            _hotelservice = hotelservice;
        }
        [HttpPost]
        public async Task<IActionResult> Index(AllHotelQueryDTO qu)
        {
            try
            {
                QueryDetailBundleDTO a = new QueryDetailBundleDTO();
                List<HotelDetailDTO> t = await _hotelservice.GetAllDetails(qu);
                if (t == null)
                {
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                else
                {
                    return View(t);
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<IActionResult> HotelDetail(string offerId, string hotelId, int numtrav, string checkinstr)
        {
            HotelQueryDTO dto = new HotelQueryDTO
            {
                HotelId = hotelId,
                NumberOfTravellers = numtrav
            };
            var offerIds = new List<string>();
            offerIds.Add(offerId);
            HotelDetailGetOffersDTO dt = await _hotelservice.GetOfferHotelDetail(offerIds);
            if (dt == null)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }

            return View("HotelDetail", dt);
        }

    }
}
