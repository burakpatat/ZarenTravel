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
    public partial class ProjectTableColumnsGetByDependencyConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByDependencyConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByDependencyConfigurationsFunc(DependencyConfiguration={DependencyConfiguration})")]
        public IActionResult ProjectTableColumnsGetByDependencyConfigurationsFunc([FromODataUri] string DependencyConfiguration)
        {
            this.OnProjectTableColumnsGetByDependencyConfigurationsDefaultParams(ref DependencyConfiguration);

            var items = this.context.ProjectTableColumnsGetByDependencyConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByDependencyConfiguration] @DependencyConfiguration={0}", DependencyConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByDependencyConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByDependencyConfigurationsDefaultParams(ref string DependencyConfiguration);

        partial void OnProjectTableColumnsGetByDependencyConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDependencyConfiguration> items);
    }
}
