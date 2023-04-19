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
    public partial class CountryGetByCurrencyCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByCurrencyCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByCurrencyCodesFunc(CurrencyCode={CurrencyCode})")]
        public IActionResult CountryGetByCurrencyCodesFunc([FromODataUri] string CurrencyCode)
        {
            this.OnCountryGetByCurrencyCodesDefaultParams(ref CurrencyCode);

            var items = this.context.CountryGetByCurrencyCodes.FromSqlRaw("EXEC [dbo].[CountryGetByCurrencyCode] @CurrencyCode={0}", CurrencyCode).ToList().AsQueryable();

            this.OnCountryGetByCurrencyCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByCurrencyCodesDefaultParams(ref string CurrencyCode);

        partial void OnCountryGetByCurrencyCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyCode> items);
    }
}
