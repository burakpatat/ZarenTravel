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
    public partial class CountryGetByEastsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByEastsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByEastsFunc(East={East})")]
        public IActionResult CountryGetByEastsFunc([FromODataUri] string East)
        {
            this.OnCountryGetByEastsDefaultParams(ref East);

            var items = this.context.CountryGetByEasts.FromSqlRaw("EXEC [dbo].[CountryGetByEast] @East={0}", East).ToList().AsQueryable();

            this.OnCountryGetByEastsInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByEastsDefaultParams(ref string East);

        partial void OnCountryGetByEastsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByEast> items);
    }
}
