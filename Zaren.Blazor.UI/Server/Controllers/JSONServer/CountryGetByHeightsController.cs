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
    public partial class CountryGetByHeightsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByHeightsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByHeightsFunc(Height={Height})")]
        public IActionResult CountryGetByHeightsFunc([FromODataUri] string Height)
        {
            this.OnCountryGetByHeightsDefaultParams(ref Height);

            var items = this.context.CountryGetByHeights.FromSqlRaw("EXEC [dbo].[CountryGetByHeight] @Height={0}", Height).ToList().AsQueryable();

            this.OnCountryGetByHeightsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByHeightsDefaultParams(ref string Height);

        partial void OnCountryGetByHeightsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByHeight> items);
    }
}
