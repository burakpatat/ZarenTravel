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
    public partial class ProjectConfigurationsGetByBackgroundJobConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByBackgroundJobConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByBackgroundJobConfigurationsFunc(BackgroundJobConfiguration={BackgroundJobConfiguration})")]
        public IActionResult ProjectConfigurationsGetByBackgroundJobConfigurationsFunc([FromODataUri] string BackgroundJobConfiguration)
        {
            this.OnProjectConfigurationsGetByBackgroundJobConfigurationsDefaultParams(ref BackgroundJobConfiguration);

            var items = this.context.ProjectConfigurationsGetByBackgroundJobConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByBackgroundJobConfiguration] @BackgroundJobConfiguration={0}", BackgroundJobConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByBackgroundJobConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByBackgroundJobConfigurationsDefaultParams(ref string BackgroundJobConfiguration);

        partial void OnProjectConfigurationsGetByBackgroundJobConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackgroundJobConfiguration> items);
    }
}
