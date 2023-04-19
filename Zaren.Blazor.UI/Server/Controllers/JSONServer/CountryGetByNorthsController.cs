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
    public partial class CountryGetByNorthsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByNorthsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByNorthsFunc(North={North})")]
        public IActionResult CountryGetByNorthsFunc([FromODataUri] string North)
        {
            this.OnCountryGetByNorthsDefaultParams(ref North);

            var items = this.context.CountryGetByNorths.FromSqlRaw("EXEC [dbo].[CountryGetByNorth] @North={0}", North).ToList().AsQueryable();

            this.OnCountryGetByNorthsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByNorthsDefaultParams(ref string North);

        partial void OnCountryGetByNorthsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByNorth> items);
    }
}
