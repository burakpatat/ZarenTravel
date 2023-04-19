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
    public partial class CountryGetByPopulationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByPopulationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByPopulationsFunc(Population={Population})")]
        public IActionResult CountryGetByPopulationsFunc([FromODataUri] string Population)
        {
            this.OnCountryGetByPopulationsDefaultParams(ref Population);

            var items = this.context.CountryGetByPopulations.FromSqlRaw("EXEC [dbo].[CountryGetByPopulation] @Population={0}", Population).ToList().AsQueryable();

            this.OnCountryGetByPopulationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByPopulationsDefaultParams(ref string Population);

        partial void OnCountryGetByPopulationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByPopulation> items);
    }
}
