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
    public partial class ProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsFunc(LogCodeMergeDateDBConnection={LogCodeMergeDateDBConnection})")]
        public IActionResult ProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsFunc([FromODataUri] string LogCodeMergeDateDBConnection)
        {
            this.OnProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsDefaultParams(ref LogCodeMergeDateDBConnection);

            var items = this.context.ProjectPageComponentElementsGetByLogCodeMergeDateDbConnections.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByLogCodeMergeDateDBConnection] @LogCodeMergeDateDBConnection={0}", LogCodeMergeDateDBConnection).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsDefaultParams(ref string LogCodeMergeDateDBConnection);

        partial void OnProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbConnection> items);
    }
}
