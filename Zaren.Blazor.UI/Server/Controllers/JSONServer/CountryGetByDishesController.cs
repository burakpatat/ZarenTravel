using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    public partial class CountryGetByDishesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByDishesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByDishesFunc(Dish={Dish})")]
        public IActionResult CountryGetByDishesFunc([FromODataUri] string Dish)
        {
            this.OnCountryGetByDishesDefaultParams(ref Dish);

            var items = this.context.CountryGetByDishes.FromSqlRaw("EXEC [dbo].[CountryGetByDish] @Dish={0}", Dish).ToList().AsQueryable();

            this.OnCountryGetByDishesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByDishesDefaultParams(ref string Dish);

        partial void OnCountryGetByDishesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByDish> items);
    }
}
