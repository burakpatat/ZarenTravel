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
    public partial class ProjectConfigurationKeyAndValueGetByConfigurationValueTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByConfigurationValueTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByConfigurationValueTypesFunc(ConfigurationValueType={ConfigurationValueType})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByConfigurationValueTypesFunc([FromODataUri] int? ConfigurationValueType)
        {
            this.OnProjectConfigurationKeyAndValueGetByConfigurationValueTypesDefaultParams(ref ConfigurationValueType);

            var items = this.context.ProjectConfigurationKeyAndValueGetByConfigurationValueTypes.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByConfigurationValueType] @ConfigurationValueType={0}", ConfigurationValueType).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByConfigurationValueTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationValueTypesDefaultParams(ref int? ConfigurationValueType);

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationValueTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValueType> items);
    }
}
