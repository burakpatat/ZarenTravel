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
    public partial class ProjectFunctionsGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectFunctionsGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectFunctionsGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectFunctionsGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectFunctionsGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCommission> items);
    }
}
