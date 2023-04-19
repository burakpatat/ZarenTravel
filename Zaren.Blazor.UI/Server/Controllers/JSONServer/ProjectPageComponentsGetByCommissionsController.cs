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
    public partial class ProjectPageComponentsGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectPageComponentsGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectPageComponentsGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectPageComponentsGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectPageComponentsGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCommission> items);
    }
}
