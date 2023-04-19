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
    public partial class CountryGetByShortNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByShortNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByShortNamesFunc(ShortName={ShortName})")]
        public IActionResult CountryGetByShortNamesFunc([FromODataUri] string ShortName)
        {
            this.OnCountryGetByShortNamesDefaultParams(ref ShortName);

            var items = this.context.CountryGetByShortNames.FromSqlRaw("EXEC [dbo].[CountryGetByShortName] @ShortName={0}", ShortName).ToList().AsQueryable();

            this.OnCountryGetByShortNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByShortNamesDefaultParams(ref string ShortName);

        partial void OnCountryGetByShortNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByShortName> items);
    }
}
