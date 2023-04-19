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
    public partial class ProjectFunctionsGetByPricesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByPricesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByPricesFunc(Price={Price})")]
        public IActionResult ProjectFunctionsGetByPricesFunc([FromODataUri] decimal? Price)
        {
            this.OnProjectFunctionsGetByPricesDefaultParams(ref Price);

            var items = this.context.ProjectFunctionsGetByPrices.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByPrice] @Price={0}", Price).ToList().AsQueryable();

            this.OnProjectFunctionsGetByPricesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByPricesDefaultParams(ref decimal? Price);

        partial void OnProjectFunctionsGetByPricesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPrice> items);
    }
}
