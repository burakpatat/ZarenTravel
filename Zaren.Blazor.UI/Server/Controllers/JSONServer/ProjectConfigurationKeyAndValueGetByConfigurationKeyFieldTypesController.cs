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
    public partial class ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesFunc(ConfigurationKeyFieldType={ConfigurationKeyFieldType})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesFunc([FromODataUri] string ConfigurationKeyFieldType)
        {
            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesDefaultParams(ref ConfigurationKeyFieldType);

            var items = this.context.ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypes.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldType] @ConfigurationKeyFieldType={0}", ConfigurationKeyFieldType).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesDefaultParams(ref string ConfigurationKeyFieldType);

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldType> items);
    }
}
