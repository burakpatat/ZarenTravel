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
    public partial class ProjectFunctionsGetByRoutesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByRoutesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByRoutesFunc(Route={Route})")]
        public IActionResult ProjectFunctionsGetByRoutesFunc([FromODataUri] string Route)
        {
            this.OnProjectFunctionsGetByRoutesDefaultParams(ref Route);

            var items = this.context.ProjectFunctionsGetByRoutes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByRoute] @Route={0}", Route).ToList().AsQueryable();

            this.OnProjectFunctionsGetByRoutesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByRoutesDefaultParams(ref string Route);

        partial void OnProjectFunctionsGetByRoutesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRoute> items);
    }
}
