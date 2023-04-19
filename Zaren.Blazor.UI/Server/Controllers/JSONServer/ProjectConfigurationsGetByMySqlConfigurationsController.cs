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
    public partial class ProjectConfigurationsGetByMySqlConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByMySqlConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByMySqlConfigurationsFunc(MySqlConfiguration={MySqlConfiguration})")]
        public IActionResult ProjectConfigurationsGetByMySqlConfigurationsFunc([FromODataUri] string MySqlConfiguration)
        {
            this.OnProjectConfigurationsGetByMySqlConfigurationsDefaultParams(ref MySqlConfiguration);

            var items = this.context.ProjectConfigurationsGetByMySqlConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByMySqlConfiguration] @MySqlConfiguration={0}", MySqlConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByMySqlConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByMySqlConfigurationsDefaultParams(ref string MySqlConfiguration);

        partial void OnProjectConfigurationsGetByMySqlConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMySqlConfiguration> items);
    }
}
