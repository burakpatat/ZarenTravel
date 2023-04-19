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
    public partial class ProjectTablesGetByUserProjectConnectionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByUserProjectConnectionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByUserProjectConnectionsFunc(UserProjectConnections={UserProjectConnections})")]
        public IActionResult ProjectTablesGetByUserProjectConnectionsFunc([FromODataUri] string UserProjectConnections)
        {
            this.OnProjectTablesGetByUserProjectConnectionsDefaultParams(ref UserProjectConnections);

            var items = this.context.ProjectTablesGetByUserProjectConnections.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByUserProjectConnections] @UserProjectConnections={0}", UserProjectConnections).ToList().AsQueryable();

            this.OnProjectTablesGetByUserProjectConnectionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByUserProjectConnectionsDefaultParams(ref string UserProjectConnections);

        partial void OnProjectTablesGetByUserProjectConnectionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUserProjectConnection> items);
    }
}
