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
    public partial class CountryGetByCitiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByCitiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByCitiesFunc(City={City})")]
        public IActionResult CountryGetByCitiesFunc([FromODataUri] string City)
        {
            this.OnCountryGetByCitiesDefaultParams(ref City);

            var items = this.context.CountryGetByCities.FromSqlRaw("EXEC [dbo].[CountryGetByCity] @City={0}", City).ToList().AsQueryable();

            this.OnCountryGetByCitiesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByCitiesDefaultParams(ref string City);

        partial void OnCountryGetByCitiesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByCity> items);
    }
}
