using AutoMapper;
using BirlesikOdeme.API.Dtos;
using BirlesikOdeme.Core.Entities.Dtos;
using BirlesikOdeme.Core.Entities.Mernis;
using BirlesikOdeme.Core.Entities.Payment;
using BirlesikOdeme.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikOdeme.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMernisService mernisService;
        private readonly IMapper mapper;
        private readonly IRestService restService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMernisService mernisService, IMapper mapper, IRestService restService, ILogger<HomeController> logger)
        {
            this.mernisService = mernisService;
            this.mapper = mapper;
            this.restService = restService;
            _logger = logger;   
        }

        [HttpPost]
        public async Task<IActionResult> CheckMernis([FromBody] CitizenRequestModel request)
        {
            _logger.Log(LogLevel.Information, "Request geldi."); //nlog.config dosyasına yazıldığı yer belirtilmiştir.
            var citizenModel = mapper.Map<Citizen>(request);
            var result = await mernisService.CheckTCNumber(citizenModel);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Sales([FromBody] SalesRequestModel request)
        {
            var salesModel = mapper.Map<SalesModel>(request);
            var result =await restService.Sales(salesModel);
            return Ok(result);

        }
    }
}
