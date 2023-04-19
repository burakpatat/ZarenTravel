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
    public partial class ProjectFunctionGroupsGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectFunctionGroupsGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectFunctionGroupsGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectFunctionGroupsGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectFunctionGroupsGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCommission> items);
    }
}
