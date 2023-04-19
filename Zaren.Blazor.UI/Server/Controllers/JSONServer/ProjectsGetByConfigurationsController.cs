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
    public partial class ProjectsGetByConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByConfigurationsFunc(Configuration={Configuration})")]
        public IActionResult ProjectsGetByConfigurationsFunc([FromODataUri] string Configuration)
        {
            this.OnProjectsGetByConfigurationsDefaultParams(ref Configuration);

            var items = this.context.ProjectsGetByConfigurations.FromSqlRaw("EXEC [dbo].[ProjectsGetByConfiguration] @Configuration={0}", Configuration).ToList().AsQueryable();

            this.OnProjectsGetByConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByConfigurationsDefaultParams(ref string Configuration);

        partial void OnProjectsGetByConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByConfiguration> items);
    }
}
