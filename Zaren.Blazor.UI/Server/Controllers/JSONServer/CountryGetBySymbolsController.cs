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
    public partial class CountryGetBySymbolsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetBySymbolsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetBySymbolsFunc(Symbol={Symbol})")]
        public IActionResult CountryGetBySymbolsFunc([FromODataUri] string Symbol)
        {
            this.OnCountryGetBySymbolsDefaultParams(ref Symbol);

            var items = this.context.CountryGetBySymbols.FromSqlRaw("EXEC [dbo].[CountryGetBySymbol] @Symbol={0}", Symbol).ToList().AsQueryable();

            this.OnCountryGetBySymbolsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetBySymbolsDefaultParams(ref string Symbol);

        partial void OnCountryGetBySymbolsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetBySymbol> items);
    }
}
