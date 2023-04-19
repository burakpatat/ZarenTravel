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
    public partial class ProjectConfigurationsGetByFigmaConfigirationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByFigmaConfigirationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByFigmaConfigirationsFunc(FigmaConfigiration={FigmaConfigiration})")]
        public IActionResult ProjectConfigurationsGetByFigmaConfigirationsFunc([FromODataUri] string FigmaConfigiration)
        {
            this.OnProjectConfigurationsGetByFigmaConfigirationsDefaultParams(ref FigmaConfigiration);

            var items = this.context.ProjectConfigurationsGetByFigmaConfigirations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByFigmaConfigiration] @FigmaConfigiration={0}", FigmaConfigiration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByFigmaConfigirationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByFigmaConfigirationsDefaultParams(ref string FigmaConfigiration);

        partial void OnProjectConfigurationsGetByFigmaConfigirationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFigmaConfigiration> items);
    }
}
