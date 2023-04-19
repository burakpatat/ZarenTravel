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
    public partial class ProjectConfigurationsGetByDiagramConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDiagramConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDiagramConfigurationsFunc(DiagramConfiguration={DiagramConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDiagramConfigurationsFunc([FromODataUri] string DiagramConfiguration)
        {
            this.OnProjectConfigurationsGetByDiagramConfigurationsDefaultParams(ref DiagramConfiguration);

            var items = this.context.ProjectConfigurationsGetByDiagramConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDiagramConfiguration] @DiagramConfiguration={0}", DiagramConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDiagramConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDiagramConfigurationsDefaultParams(ref string DiagramConfiguration);

        partial void OnProjectConfigurationsGetByDiagramConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDiagramConfiguration> items);
    }
}
