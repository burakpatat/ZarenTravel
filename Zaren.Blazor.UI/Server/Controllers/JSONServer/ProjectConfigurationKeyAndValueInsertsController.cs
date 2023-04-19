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
    public partial class ProjectConfigurationKeyAndValueInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueInsertsFunc(ConfigurationKey={ConfigurationKey},ConfigurationKeyFieldType={ConfigurationKeyFieldType},ConfigurationKeyFromInputType={ConfigurationKeyFromInputType},ConfigurationValue={ConfigurationValue},ConfigurationValueType={ConfigurationValueType},ParentConfigurationKeyId={ParentConfigurationKeyId})")]
        public IActionResult ProjectConfigurationKeyAndValueInsertsFunc([FromODataUri] string ConfigurationKey, [FromODataUri] string ConfigurationKeyFieldType, [FromODataUri] int? ConfigurationKeyFromInputType, [FromODataUri] string ConfigurationValue, [FromODataUri] int? ConfigurationValueType, [FromODataUri] int? ParentConfigurationKeyId)
        {
            this.OnProjectConfigurationKeyAndValueInsertsDefaultParams(ref ConfigurationKey, ref ConfigurationKeyFieldType, ref ConfigurationKeyFromInputType, ref ConfigurationValue, ref ConfigurationValueType, ref ParentConfigurationKeyId);

            var items = this.context.ProjectConfigurationKeyAndValueInserts.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueInsert] @ConfigurationKey={0}, @ConfigurationKeyFieldType={1}, @ConfigurationKeyFromInputType={2}, @ConfigurationValue={3}, @ConfigurationValueType={4}, @ParentConfigurationKeyId={5}", ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueInsertsDefaultParams(ref string ConfigurationKey, ref string ConfigurationKeyFieldType, ref int? ConfigurationKeyFromInputType, ref string ConfigurationValue, ref int? ConfigurationValueType, ref int? ParentConfigurationKeyId);

        partial void OnProjectConfigurationKeyAndValueInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueInsert> items);
    }
}
