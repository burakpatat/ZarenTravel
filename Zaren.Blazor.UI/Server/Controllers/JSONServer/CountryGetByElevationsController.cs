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
    public partial class CountryGetByElevationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByElevationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByElevationsFunc(Elevation={Elevation})")]
        public IActionResult CountryGetByElevationsFunc([FromODataUri] string Elevation)
        {
            this.OnCountryGetByElevationsDefaultParams(ref Elevation);

            var items = this.context.CountryGetByElevations.FromSqlRaw("EXEC [dbo].[CountryGetByElevation] @Elevation={0}", Elevation).ToList().AsQueryable();

            this.OnCountryGetByElevationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByElevationsDefaultParams(ref string Elevation);

        partial void OnCountryGetByElevationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByElevation> items);
    }
}
