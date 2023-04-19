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
    public partial class CountryGetByNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByNamesFunc(Name={Name})")]
        public IActionResult CountryGetByNamesFunc([FromODataUri] string Name)
        {
            this.OnCountryGetByNamesDefaultParams(ref Name);

            var items = this.context.CountryGetByNames.FromSqlRaw("EXEC [dbo].[CountryGetByName] @Name={0}", Name).ToList().AsQueryable();

            this.OnCountryGetByNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByNamesDefaultParams(ref string Name);

        partial void OnCountryGetByNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByName> items);
    }
}
