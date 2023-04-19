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
    public partial class CountryGetByDensitiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByDensitiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByDensitiesFunc(Density={Density})")]
        public IActionResult CountryGetByDensitiesFunc([FromODataUri] string Density)
        {
            this.OnCountryGetByDensitiesDefaultParams(ref Density);

            var items = this.context.CountryGetByDensities.FromSqlRaw("EXEC [dbo].[CountryGetByDensity] @Density={0}", Density).ToList().AsQueryable();

            this.OnCountryGetByDensitiesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByDensitiesDefaultParams(ref string Density);

        partial void OnCountryGetByDensitiesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByDensity> items);
    }
}
