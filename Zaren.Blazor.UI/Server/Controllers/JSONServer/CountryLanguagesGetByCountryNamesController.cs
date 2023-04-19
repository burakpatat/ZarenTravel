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
    public partial class CountryLanguagesGetByCountryNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryLanguagesGetByCountryNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryLanguagesGetByCountryNamesFunc(CountryName={CountryName})")]
        public IActionResult CountryLanguagesGetByCountryNamesFunc([FromODataUri] string CountryName)
        {
            this.OnCountryLanguagesGetByCountryNamesDefaultParams(ref CountryName);

            var items = this.context.CountryLanguagesGetByCountryNames.FromSqlRaw("EXEC [dbo].[CountryLanguagesGetByCountryName] @CountryName={0}", CountryName).ToList().AsQueryable();

            this.OnCountryLanguagesGetByCountryNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryLanguagesGetByCountryNamesDefaultParams(ref string CountryName);

        partial void OnCountryLanguagesGetByCountryNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryName> items);
    }
}
