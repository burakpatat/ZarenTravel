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
    public partial class ProjectTablesGetByProjectTableConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByProjectTableConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByProjectTableConfigurationsFunc(ProjectTableConfiguration={ProjectTableConfiguration})")]
        public IActionResult ProjectTablesGetByProjectTableConfigurationsFunc([FromODataUri] string ProjectTableConfiguration)
        {
            this.OnProjectTablesGetByProjectTableConfigurationsDefaultParams(ref ProjectTableConfiguration);

            var items = this.context.ProjectTablesGetByProjectTableConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByProjectTableConfiguration] @ProjectTableConfiguration={0}", ProjectTableConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByProjectTableConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByProjectTableConfigurationsDefaultParams(ref string ProjectTableConfiguration);

        partial void OnProjectTablesGetByProjectTableConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectTableConfiguration> items);
    }
}
