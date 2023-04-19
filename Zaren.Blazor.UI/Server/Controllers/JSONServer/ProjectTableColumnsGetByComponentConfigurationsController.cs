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
    public partial class ProjectTableColumnsGetByComponentConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByComponentConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByComponentConfigurationsFunc(ComponentConfiguration={ComponentConfiguration})")]
        public IActionResult ProjectTableColumnsGetByComponentConfigurationsFunc([FromODataUri] string ComponentConfiguration)
        {
            this.OnProjectTableColumnsGetByComponentConfigurationsDefaultParams(ref ComponentConfiguration);

            var items = this.context.ProjectTableColumnsGetByComponentConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByComponentConfiguration] @ComponentConfiguration={0}", ComponentConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByComponentConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByComponentConfigurationsDefaultParams(ref string ComponentConfiguration);

        partial void OnProjectTableColumnsGetByComponentConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComponentConfiguration> items);
    }
}
