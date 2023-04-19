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
public class TravellerController : ControllerBase
{ 
    [Inject]
    protected SecurityService Security { get; set; } 
    private readonly string _strConnString; 
    private IDistributedCache _cache;
    private IConfiguration _configuration; 
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TravellerController(IConfiguration configuration, IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _cache = cache;
        _strConnString = configuration.GetConnectionString("ZarenTravel");
        _httpContextAccessor = httpContextAccessor;

    }

    [HttpGet("~/api/Traveller/{ReservationNumber}")]
    public ActionResult<string> TravellerList(string ReservationNumber, List<BookingTravellers> body)
    {
        return new BookingTravellersRepository(_configuration).GetByReservationNumber(ReservationNumber).ToJson();
    } 

    [HttpPost("~/api/Traveller/{ReservationNumber}")]
    public ActionResult<string> Traveller(string ReservationNumber, [FromBody] Dictionary<string, object> BookingTravellers)
    {
        var repo = new BookingReservationsRepository(_configuration);
        var travellerRepo = new BookingTravellersRepository(_configuration);
        var currentReservation = repo.GetByTransactionId(ReservationNumber).FirstOrDefault();
        if (currentReservation != null)
        {
            var json = BookingTravellers.objectDictionaryToJson();
            var myDeserializedClass = JsonConvert.DeserializeObject<BookingTravellersPost>(json);

            if (myDeserializedClass.BookingTravellers.Any())
            {
                foreach (var item in travellerRepo.GetByReservationNumber(ReservationNumber))
                {
                    travellerRepo.Delete(item);
                }
            }
            var i = 0;
            foreach (var item in myDeserializedClass.BookingTravellers)
            {
                if (i == 0)
                {
                    currentReservation.Note = item.Note;
                    repo.Update(currentReservation);
                }
                var model = new BookingTravellers()
                {
                    BirthDate = Convert.ToDateTime(item.BirthDate),
                    CreatedDate = DateTime.Now,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ReservationNumber = ReservationNumber,
                    Gender = item.Gender,
                    GovernmentId = item.GovernmentId,
                    MobileNumber = item.MobileNumber,
                };
                if (i == 0)
                    model.IsFirstContact = true;
                else
                    model.IsFirstContact = false;
                travellerRepo.Insert(model);
                i++;
            }
        }
        return travellerRepo.GetByReservationNumber(ReservationNumber).ToJson();
    }

 
}
