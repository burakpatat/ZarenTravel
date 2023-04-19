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
    public partial class ProjectConfigurationsGetByReactConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByReactConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByReactConfigurationsFunc(ReactConfiguration={ReactConfiguration})")]
        public IActionResult ProjectConfigurationsGetByReactConfigurationsFunc([FromODataUri] string ReactConfiguration)
        {
            this.OnProjectConfigurationsGetByReactConfigurationsDefaultParams(ref ReactConfiguration);

            var items = this.context.ProjectConfigurationsGetByReactConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByReactConfiguration] @ReactConfiguration={0}", ReactConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByReactConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByReactConfigurationsDefaultParams(ref string ReactConfiguration);

        partial void OnProjectConfigurationsGetByReactConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByReactConfiguration> items);
    }
}
