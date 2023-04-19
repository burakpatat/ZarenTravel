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
    public partial class ProjectTablesGetByApiConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByApiConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByApiConfigurationsFunc(ApiConfiguration={ApiConfiguration})")]
        public IActionResult ProjectTablesGetByApiConfigurationsFunc([FromODataUri] string ApiConfiguration)
        {
            this.OnProjectTablesGetByApiConfigurationsDefaultParams(ref ApiConfiguration);

            var items = this.context.ProjectTablesGetByApiConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByApiConfiguration] @ApiConfiguration={0}", ApiConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByApiConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByApiConfigurationsDefaultParams(ref string ApiConfiguration);

        partial void OnProjectTablesGetByApiConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByApiConfiguration> items);
    }
}
