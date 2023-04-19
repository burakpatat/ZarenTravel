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
    public partial class ProjectTableColumnsGetByPricesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByPricesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByPricesFunc(Price={Price})")]
        public IActionResult ProjectTableColumnsGetByPricesFunc([FromODataUri] decimal? Price)
        {
            this.OnProjectTableColumnsGetByPricesDefaultParams(ref Price);

            var items = this.context.ProjectTableColumnsGetByPrices.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByPrice] @Price={0}", Price).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByPricesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByPricesDefaultParams(ref decimal? Price);

        partial void OnProjectTableColumnsGetByPricesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByPrice> items);
    }
}
