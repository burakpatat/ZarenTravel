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
    public partial class ProjectTableColumnsGetByColumnsConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByColumnsConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByColumnsConfigurationsFunc(ColumnsConfiguration={ColumnsConfiguration})")]
        public IActionResult ProjectTableColumnsGetByColumnsConfigurationsFunc([FromODataUri] string ColumnsConfiguration)
        {
            this.OnProjectTableColumnsGetByColumnsConfigurationsDefaultParams(ref ColumnsConfiguration);

            var items = this.context.ProjectTableColumnsGetByColumnsConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByColumnsConfiguration] @ColumnsConfiguration={0}", ColumnsConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByColumnsConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByColumnsConfigurationsDefaultParams(ref string ColumnsConfiguration);

        partial void OnProjectTableColumnsGetByColumnsConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnsConfiguration> items);
    }
}
