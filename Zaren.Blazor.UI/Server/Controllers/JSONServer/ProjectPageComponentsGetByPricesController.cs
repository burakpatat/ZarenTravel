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
    public partial class ProjectPageComponentsGetByPricesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByPricesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByPricesFunc(Price={Price})")]
        public IActionResult ProjectPageComponentsGetByPricesFunc([FromODataUri] decimal? Price)
        {
            this.OnProjectPageComponentsGetByPricesDefaultParams(ref Price);

            var items = this.context.ProjectPageComponentsGetByPrices.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByPrice] @Price={0}", Price).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByPricesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByPricesDefaultParams(ref decimal? Price);

        partial void OnProjectPageComponentsGetByPricesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByPrice> items);
    }
}
