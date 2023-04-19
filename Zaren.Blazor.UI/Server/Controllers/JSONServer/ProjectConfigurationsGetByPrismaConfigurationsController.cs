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
    public partial class ProjectConfigurationsGetByPrismaConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByPrismaConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByPrismaConfigurationsFunc(PrismaConfiguration={PrismaConfiguration})")]
        public IActionResult ProjectConfigurationsGetByPrismaConfigurationsFunc([FromODataUri] string PrismaConfiguration)
        {
            this.OnProjectConfigurationsGetByPrismaConfigurationsDefaultParams(ref PrismaConfiguration);

            var items = this.context.ProjectConfigurationsGetByPrismaConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByPrismaConfiguration] @PrismaConfiguration={0}", PrismaConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByPrismaConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByPrismaConfigurationsDefaultParams(ref string PrismaConfiguration);

        partial void OnProjectConfigurationsGetByPrismaConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPrismaConfiguration> items);
    }
}
