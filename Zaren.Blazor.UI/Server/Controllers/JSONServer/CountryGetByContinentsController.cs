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
    public partial class CountryGetByContinentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByContinentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByContinentsFunc(Continent={Continent})")]
        public IActionResult CountryGetByContinentsFunc([FromODataUri] string Continent)
        {
            this.OnCountryGetByContinentsDefaultParams(ref Continent);

            var items = this.context.CountryGetByContinents.FromSqlRaw("EXEC [dbo].[CountryGetByContinent] @Continent={0}", Continent).ToList().AsQueryable();

            this.OnCountryGetByContinentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByContinentsDefaultParams(ref string Continent);

        partial void OnCountryGetByContinentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByContinent> items);
    }
}
