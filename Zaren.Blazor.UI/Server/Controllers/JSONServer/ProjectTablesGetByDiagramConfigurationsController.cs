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
    public partial class ProjectTablesGetByDiagramConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByDiagramConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByDiagramConfigurationsFunc(DiagramConfiguration={DiagramConfiguration})")]
        public IActionResult ProjectTablesGetByDiagramConfigurationsFunc([FromODataUri] string DiagramConfiguration)
        {
            this.OnProjectTablesGetByDiagramConfigurationsDefaultParams(ref DiagramConfiguration);

            var items = this.context.ProjectTablesGetByDiagramConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByDiagramConfiguration] @DiagramConfiguration={0}", DiagramConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByDiagramConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByDiagramConfigurationsDefaultParams(ref string DiagramConfiguration);

        partial void OnProjectTablesGetByDiagramConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDiagramConfiguration> items);
    }
}
