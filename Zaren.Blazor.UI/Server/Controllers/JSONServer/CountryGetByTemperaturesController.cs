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
    public partial class CountryGetByTemperaturesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByTemperaturesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByTemperaturesFunc(Temperature={Temperature})")]
        public IActionResult CountryGetByTemperaturesFunc([FromODataUri] string Temperature)
        {
            this.OnCountryGetByTemperaturesDefaultParams(ref Temperature);

            var items = this.context.CountryGetByTemperatures.FromSqlRaw("EXEC [dbo].[CountryGetByTemperature] @Temperature={0}", Temperature).ToList().AsQueryable();

            this.OnCountryGetByTemperaturesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByTemperaturesDefaultParams(ref string Temperature);

        partial void OnCountryGetByTemperaturesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByTemperature> items);
    }
}
