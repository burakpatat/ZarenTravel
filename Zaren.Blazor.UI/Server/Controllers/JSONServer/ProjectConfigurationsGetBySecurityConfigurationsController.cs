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
    public partial class ProjectConfigurationsGetBySecurityConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetBySecurityConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetBySecurityConfigurationsFunc(SecurityConfiguration={SecurityConfiguration})")]
        public IActionResult ProjectConfigurationsGetBySecurityConfigurationsFunc([FromODataUri] string SecurityConfiguration)
        {
            this.OnProjectConfigurationsGetBySecurityConfigurationsDefaultParams(ref SecurityConfiguration);

            var items = this.context.ProjectConfigurationsGetBySecurityConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetBySecurityConfiguration] @SecurityConfiguration={0}", SecurityConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetBySecurityConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetBySecurityConfigurationsDefaultParams(ref string SecurityConfiguration);

        partial void OnProjectConfigurationsGetBySecurityConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySecurityConfiguration> items);
    }
}
