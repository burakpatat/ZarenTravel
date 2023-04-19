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
    public partial class ProjectConfigurationsGetByNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByNamesFunc(Name={Name})")]
        public IActionResult ProjectConfigurationsGetByNamesFunc([FromODataUri] string Name)
        {
            this.OnProjectConfigurationsGetByNamesDefaultParams(ref Name);

            var items = this.context.ProjectConfigurationsGetByNames.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByName] @Name={0}", Name).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByNamesDefaultParams(ref string Name);

        partial void OnProjectConfigurationsGetByNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByName> items);
    }
}
