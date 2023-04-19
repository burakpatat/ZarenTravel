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
    public partial class ProjectConfigurationsGetByHeaderConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByHeaderConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByHeaderConfigurationsFunc(HeaderConfiguration={HeaderConfiguration})")]
        public IActionResult ProjectConfigurationsGetByHeaderConfigurationsFunc([FromODataUri] string HeaderConfiguration)
        {
            this.OnProjectConfigurationsGetByHeaderConfigurationsDefaultParams(ref HeaderConfiguration);

            var items = this.context.ProjectConfigurationsGetByHeaderConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByHeaderConfiguration] @HeaderConfiguration={0}", HeaderConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByHeaderConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByHeaderConfigurationsDefaultParams(ref string HeaderConfiguration);

        partial void OnProjectConfigurationsGetByHeaderConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHeaderConfiguration> items);
    }
}
