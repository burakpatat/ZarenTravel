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
    public partial class ProjectPageComponentsGetByWebSitePagesIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByWebSitePagesIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByWebSitePagesIdsFunc(WebSitePagesId={WebSitePagesId})")]
        public IActionResult ProjectPageComponentsGetByWebSitePagesIdsFunc([FromODataUri] int? WebSitePagesId)
        {
            this.OnProjectPageComponentsGetByWebSitePagesIdsDefaultParams(ref WebSitePagesId);

            var items = this.context.ProjectPageComponentsGetByWebSitePagesIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByWebSitePagesId] @WebSitePagesId={0}", WebSitePagesId).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByWebSitePagesIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByWebSitePagesIdsDefaultParams(ref int? WebSitePagesId);

        partial void OnProjectPageComponentsGetByWebSitePagesIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByWebSitePagesId> items);
    }
}
