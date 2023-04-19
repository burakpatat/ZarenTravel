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
    public partial class CountryGetByReligionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByReligionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByReligionsFunc(Religion={Religion})")]
        public IActionResult CountryGetByReligionsFunc([FromODataUri] string Religion)
        {
            this.OnCountryGetByReligionsDefaultParams(ref Religion);

            var items = this.context.CountryGetByReligions.FromSqlRaw("EXEC [dbo].[CountryGetByReligion] @Religion={0}", Religion).ToList().AsQueryable();

            this.OnCountryGetByReligionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByReligionsDefaultParams(ref string Religion);

        partial void OnCountryGetByReligionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByReligion> items);
    }
}
