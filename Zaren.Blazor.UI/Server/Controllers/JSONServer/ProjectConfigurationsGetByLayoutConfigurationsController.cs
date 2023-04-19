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
    public partial class ProjectConfigurationsGetByLayoutConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByLayoutConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByLayoutConfigurationsFunc(LayoutConfiguration={LayoutConfiguration})")]
        public IActionResult ProjectConfigurationsGetByLayoutConfigurationsFunc([FromODataUri] string LayoutConfiguration)
        {
            this.OnProjectConfigurationsGetByLayoutConfigurationsDefaultParams(ref LayoutConfiguration);

            var items = this.context.ProjectConfigurationsGetByLayoutConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByLayoutConfiguration] @LayoutConfiguration={0}", LayoutConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByLayoutConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByLayoutConfigurationsDefaultParams(ref string LayoutConfiguration);

        partial void OnProjectConfigurationsGetByLayoutConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLayoutConfiguration> items);
    }
}
