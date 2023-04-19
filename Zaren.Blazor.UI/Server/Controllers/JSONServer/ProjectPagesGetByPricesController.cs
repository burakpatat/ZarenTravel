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
    public partial class ProjectPagesGetByPricesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByPricesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByPricesFunc(Price={Price})")]
        public IActionResult ProjectPagesGetByPricesFunc([FromODataUri] decimal? Price)
        {
            this.OnProjectPagesGetByPricesDefaultParams(ref Price);

            var items = this.context.ProjectPagesGetByPrices.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByPrice] @Price={0}", Price).ToList().AsQueryable();

            this.OnProjectPagesGetByPricesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByPricesDefaultParams(ref decimal? Price);

        partial void OnProjectPagesGetByPricesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPrice> items);
    }
}
