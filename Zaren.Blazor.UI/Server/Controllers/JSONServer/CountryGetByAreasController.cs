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
    public partial class CountryGetByAreasController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public CountryGetByAreasController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/CountryGetByAreasFunc(Area={Area})")]
        public IActionResult CountryGetByAreasFunc([FromODataUri] string Area)
        {
            this.OnCountryGetByAreasDefaultParams(ref Area);

            var items = this.context.CountryGetByAreas.FromSqlRaw("EXEC [dbo].[CountryGetByArea] @Area={0}", Area).ToList().AsQueryable();

            this.OnCountryGetByAreasInvoke(ref items);

            return Ok(items);
        }

        partial void OnCountryGetByAreasDefaultParams(ref string Area);

        partial void OnCountryGetByAreasInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.CountryGetByArea> items);
    }
}
