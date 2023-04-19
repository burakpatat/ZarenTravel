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
    public partial class ProjectPageComponentElementsGetByHasCodeBuildsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByHasCodeBuildsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByHasCodeBuildsFunc(HasCodeBuild={HasCodeBuild})")]
        public IActionResult ProjectPageComponentElementsGetByHasCodeBuildsFunc([FromODataUri] string HasCodeBuild)
        {
            this.OnProjectPageComponentElementsGetByHasCodeBuildsDefaultParams(ref HasCodeBuild);

            var items = this.context.ProjectPageComponentElementsGetByHasCodeBuilds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByHasCodeBuild] @HasCodeBuild={0}", HasCodeBuild).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByHasCodeBuildsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByHasCodeBuildsDefaultParams(ref string HasCodeBuild);

        partial void OnProjectPageComponentElementsGetByHasCodeBuildsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCodeBuild> items);
    }
}
