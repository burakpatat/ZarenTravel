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
    public partial class ProjectConfigurationsGetByFileOutputExtensionNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByFileOutputExtensionNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByFileOutputExtensionNamesFunc(FileOutputExtensionName={FileOutputExtensionName})")]
        public IActionResult ProjectConfigurationsGetByFileOutputExtensionNamesFunc([FromODataUri] string FileOutputExtensionName)
        {
            this.OnProjectConfigurationsGetByFileOutputExtensionNamesDefaultParams(ref FileOutputExtensionName);

            var items = this.context.ProjectConfigurationsGetByFileOutputExtensionNames.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByFileOutputExtensionName] @FileOutputExtensionName={0}", FileOutputExtensionName).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByFileOutputExtensionNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByFileOutputExtensionNamesDefaultParams(ref string FileOutputExtensionName);

        partial void OnProjectConfigurationsGetByFileOutputExtensionNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileOutputExtensionName> items);
    }
}
