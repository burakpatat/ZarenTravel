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
    public partial class CountryGetByCurrencyNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByCurrencyNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByCurrencyNamesFunc(CurrencyName={CurrencyName})")]
        public IActionResult CountryGetByCurrencyNamesFunc([FromODataUri] string CurrencyName)
        {
            this.OnCountryGetByCurrencyNamesDefaultParams(ref CurrencyName);

            var items = this.context.CountryGetByCurrencyNames.FromSqlRaw("EXEC [dbo].[CountryGetByCurrencyName] @CurrencyName={0}", CurrencyName).ToList().AsQueryable();

            this.OnCountryGetByCurrencyNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByCurrencyNamesDefaultParams(ref string CurrencyName);

        partial void OnCountryGetByCurrencyNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyName> items);
    }
}
