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
    public partial class ProjectConfigurationsGetByNodeJsExpressConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByNodeJsExpressConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByNodeJsExpressConfigurationsFunc(NodeJsExpressConfiguration={NodeJsExpressConfiguration})")]
        public IActionResult ProjectConfigurationsGetByNodeJsExpressConfigurationsFunc([FromODataUri] string NodeJsExpressConfiguration)
        {
            this.OnProjectConfigurationsGetByNodeJsExpressConfigurationsDefaultParams(ref NodeJsExpressConfiguration);

            var items = this.context.ProjectConfigurationsGetByNodeJsExpressConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByNodeJsExpressConfiguration] @NodeJsExpressConfiguration={0}", NodeJsExpressConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByNodeJsExpressConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByNodeJsExpressConfigurationsDefaultParams(ref string NodeJsExpressConfiguration);

        partial void OnProjectConfigurationsGetByNodeJsExpressConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNodeJsExpressConfiguration> items);
    }
}
