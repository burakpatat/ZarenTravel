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
    public partial class ProjectConfigurationKeyAndValueGetByConfigurationValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByConfigurationValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByConfigurationValuesFunc(ConfigurationValue={ConfigurationValue})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByConfigurationValuesFunc([FromODataUri] string ConfigurationValue)
        {
            this.OnProjectConfigurationKeyAndValueGetByConfigurationValuesDefaultParams(ref ConfigurationValue);

            var items = this.context.ProjectConfigurationKeyAndValueGetByConfigurationValues.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByConfigurationValue] @ConfigurationValue={0}", ConfigurationValue).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByConfigurationValuesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationValuesDefaultParams(ref string ConfigurationValue);

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationValuesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValue> items);
    }
}
