using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HudAsp.Models;

namespace HudAsp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (Context.Request.Query["IdGuid"] == null)
        {
            var model = new Model.Concrete.Transactions()
            {
                CreatedDate = DateTime.Now,
                Currency = 1,
                IdGuid = Guid.NewGuid().ToString(),
                Is3D = true,
                IsSuccess = true,
                Language = "en",
                NameSurname = "Gokhan Sahinbas",
                TotalAmount = 1250,
                UserId = 1
            };

            new TransactionsRepository().Insert(model);
            return View(model);
        }
        else
        {
            var model = new TransactionsRepository().GetByIdGuid(Request.Query["IdGuid"].ToString());
            return View(model);
        }
        


      
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}