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
    public partial class ProjectConfigurationsGetByRoleConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByRoleConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByRoleConfigurationsFunc(RoleConfiguration={RoleConfiguration})")]
        public IActionResult ProjectConfigurationsGetByRoleConfigurationsFunc([FromODataUri] string RoleConfiguration)
        {
            this.OnProjectConfigurationsGetByRoleConfigurationsDefaultParams(ref RoleConfiguration);

            var items = this.context.ProjectConfigurationsGetByRoleConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByRoleConfiguration] @RoleConfiguration={0}", RoleConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByRoleConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByRoleConfigurationsDefaultParams(ref string RoleConfiguration);

        partial void OnProjectConfigurationsGetByRoleConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRoleConfiguration> items);
    }
}
