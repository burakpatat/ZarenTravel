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
    public partial class ProjectPageComponentElementsGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectPageComponentElementsGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectPageComponentElementsGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectPageComponentElementsGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectPageComponentElementsGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCommission> items);
    }
}
