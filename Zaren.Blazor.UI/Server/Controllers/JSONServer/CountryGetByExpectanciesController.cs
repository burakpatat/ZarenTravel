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
    public partial class CountryGetByExpectanciesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByExpectanciesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByExpectanciesFunc(Expectancy={Expectancy})")]
        public IActionResult CountryGetByExpectanciesFunc([FromODataUri] string Expectancy)
        {
            this.OnCountryGetByExpectanciesDefaultParams(ref Expectancy);

            var items = this.context.CountryGetByExpectancies.FromSqlRaw("EXEC [dbo].[CountryGetByExpectancy] @Expectancy={0}", Expectancy).ToList().AsQueryable();

            this.OnCountryGetByExpectanciesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByExpectanciesDefaultParams(ref string Expectancy);

        partial void OnCountryGetByExpectanciesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByExpectancy> items);
    }
}
