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
    public partial class ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesFunc(ConfigurationKeyFromInputType={ConfigurationKeyFromInputType})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesFunc([FromODataUri] int? ConfigurationKeyFromInputType)
        {
            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesDefaultParams(ref ConfigurationKeyFromInputType);

            var items = this.context.ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypes.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputType] @ConfigurationKeyFromInputType={0}", ConfigurationKeyFromInputType).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesDefaultParams(ref int? ConfigurationKeyFromInputType);

        partial void OnProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputType> items);
    }
}
