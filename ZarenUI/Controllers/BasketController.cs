using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Model.Concrete;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using ZarenUI;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[Route("api/[controller]")]
public class BasketController : ControllerBase
{ 
    [Inject]
    protected SecurityService Security { get; set; } 
    private readonly string _strConnString; 
    private IDistributedCache _cache;
    private IConfiguration _configuration; 
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BasketController(IConfiguration configuration, IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
    { 
        _configuration = configuration;
        _cache = cache;
        _strConnString = configuration.GetConnectionString("ZarenTravel"); 
        _httpContextAccessor = httpContextAccessor;
    
    }
  
   

     
    [HttpPut("~/api/basket/{ReservationId}")]
    public ActionResult<string> UpdateBasket(int ReservationId)
    {
        using (var context= new BookingReservationsRepository(_configuration))
        {
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
            var currentCookie= context.GetByID(ReservationId);
            if (currentCookie!=null && cookie!=null && currentCookie.CookieId== cookie)
            {
                currentCookie.OnBasket = false;
                context.Update(currentCookie);
                return context.GetByCookieId(cookie).Where(a=>a.OnBasket==true).OrderByDescending(a=>a.Id).ToJson();
            }
            return "";
            
        }
    } 

 

    [HttpGet("~/ConvertDate/{date}/{format}")]
    public ActionResult<string> ConvertDate(string date, string format)
    {

        if (date != null && date != "")
        {
            char splitKey = ' ';
            if (date.Contains("."))
                splitKey = '.';
            else if (date.Contains("-"))
                splitKey = '-';
            else if (date.Contains("/"))
                splitKey = '/';
            var currentDate = DateTime.Now;
            if (date.Length > 8)
                currentDate = new DateTime(year: (date.Split(splitKey)[2]).ToInt32(), month: date.Split(splitKey)[1].ToInt32(), day: date.Split(splitKey)[0].ToInt32());
            else
                currentDate = new DateTime(year: ("20" + date.Split(splitKey)[2]).ToInt32(), month: date.Split(splitKey)[1].ToInt32(), day: date.Split(splitKey)[0].ToInt32());

            date = currentDate.AddDays(1).ToString(format);
        }
        return date.ToJson();
    } 

    [HttpGet("~/price/{price}")]
    public ActionResult<string> SetCommission(string price)
    {
        var urlHost = HttpContext.Request.Host;
        return "".ToJson();
    }

    [HttpGet("~/api/i18/{culture}")]
    public ActionResult<string> Translate(string culture)
    {
        var encKey = "Translate:" + culture;
        if (_cache.GetString(encKey) == null)
        {
            var list = new ResourcesRepository(_configuration).GetByLanguageCode(culture).ToJson();
            _cache.SetString(encKey, list);
            return list;
        }
        else
        {
            return _cache.GetString(encKey);
        }
    }
}
