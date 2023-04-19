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
    public partial class CountryGetByIndependencesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByIndependencesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByIndependencesFunc(Independence={Independence})")]
        public IActionResult CountryGetByIndependencesFunc([FromODataUri] string Independence)
        {
            this.OnCountryGetByIndependencesDefaultParams(ref Independence);

            var items = this.context.CountryGetByIndependences.FromSqlRaw("EXEC [dbo].[CountryGetByIndependence] @Independence={0}", Independence).ToList().AsQueryable();

            this.OnCountryGetByIndependencesInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByIndependencesDefaultParams(ref string Independence);

        partial void OnCountryGetByIndependencesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByIndependence> items);
    }
}
