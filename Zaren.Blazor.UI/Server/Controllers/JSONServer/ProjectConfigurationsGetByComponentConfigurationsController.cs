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
    public partial class ProjectConfigurationsGetByComponentConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByComponentConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByComponentConfigurationsFunc(ComponentConfiguration={ComponentConfiguration})")]
        public IActionResult ProjectConfigurationsGetByComponentConfigurationsFunc([FromODataUri] string ComponentConfiguration)
        {
            this.OnProjectConfigurationsGetByComponentConfigurationsDefaultParams(ref ComponentConfiguration);

            var items = this.context.ProjectConfigurationsGetByComponentConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByComponentConfiguration] @ComponentConfiguration={0}", ComponentConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByComponentConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByComponentConfigurationsDefaultParams(ref string ComponentConfiguration);

        partial void OnProjectConfigurationsGetByComponentConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByComponentConfiguration> items);
    }
}
