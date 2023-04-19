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
    public partial class CountryGetByWestsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByWestsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByWestsFunc(West={West})")]
        public IActionResult CountryGetByWestsFunc([FromODataUri] string West)
        {
            this.OnCountryGetByWestsDefaultParams(ref West);

            var items = this.context.CountryGetByWests.FromSqlRaw("EXEC [dbo].[CountryGetByWest] @West={0}", West).ToList().AsQueryable();

            this.OnCountryGetByWestsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByWestsDefaultParams(ref string West);

        partial void OnCountryGetByWestsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByWest> items);
    }
}
