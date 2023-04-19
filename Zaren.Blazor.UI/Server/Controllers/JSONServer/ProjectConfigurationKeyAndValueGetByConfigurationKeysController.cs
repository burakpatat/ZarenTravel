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
    public partial class ProjectConfigurationKeyAndValueGetByConfigurationKeysController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByConfigurationKeysController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByConfigurationKeysFunc(ConfigurationKey={ConfigurationKey})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByConfigurationKeysFunc([FromODataUri] string ConfigurationKey)
        {
            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeysDefaultParams(ref ConfigurationKey);

            var items = this.context.ProjectConfigurationKeyAndValueGetByConfigurationKeys.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByConfigurationKey] @ConfigurationKey={0}", ConfigurationKey).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeysInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeysDefaultParams(ref string ConfigurationKey);

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeysInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKey> items);
    }
}
