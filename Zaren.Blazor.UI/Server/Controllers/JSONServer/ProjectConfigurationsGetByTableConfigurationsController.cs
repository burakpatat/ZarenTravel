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
    public partial class ProjectConfigurationsGetByTableConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTableConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTableConfigurationsFunc(TableConfiguration={TableConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTableConfigurationsFunc([FromODataUri] string TableConfiguration)
        {
            this.OnProjectConfigurationsGetByTableConfigurationsDefaultParams(ref TableConfiguration);

            var items = this.context.ProjectConfigurationsGetByTableConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTableConfiguration] @TableConfiguration={0}", TableConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTableConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTableConfigurationsDefaultParams(ref string TableConfiguration);

        partial void OnProjectConfigurationsGetByTableConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTableConfiguration> items);
    }
}
