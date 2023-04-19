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
    public partial class CountryGetByLocationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByLocationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByLocationsFunc(Location={Location})")]
        public IActionResult CountryGetByLocationsFunc([FromODataUri] string Location)
        {
            this.OnCountryGetByLocationsDefaultParams(ref Location);

            var items = this.context.CountryGetByLocations.FromSqlRaw("EXEC [dbo].[CountryGetByLocation] @Location={0}", Location).ToList().AsQueryable();

            this.OnCountryGetByLocationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByLocationsDefaultParams(ref string Location);

        partial void OnCountryGetByLocationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByLocation> items);
    }
}
