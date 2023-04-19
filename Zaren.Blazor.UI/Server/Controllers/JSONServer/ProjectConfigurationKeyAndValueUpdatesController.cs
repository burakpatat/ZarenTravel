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
    public partial class ProjectConfigurationKeyAndValueUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueUpdatesFunc(Id={Id},ConfigurationKey={ConfigurationKey},ConfigurationKeyFieldType={ConfigurationKeyFieldType},ConfigurationKeyFromInputType={ConfigurationKeyFromInputType},ConfigurationValue={ConfigurationValue},ConfigurationValueType={ConfigurationValueType},ParentConfigurationKeyId={ParentConfigurationKeyId})")]
        public IActionResult ProjectConfigurationKeyAndValueUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string ConfigurationKey, [FromODataUri] string ConfigurationKeyFieldType, [FromODataUri] int? ConfigurationKeyFromInputType, [FromODataUri] string ConfigurationValue, [FromODataUri] int? ConfigurationValueType, [FromODataUri] int? ParentConfigurationKeyId)
        {
            this.OnProjectConfigurationKeyAndValueUpdatesDefaultParams(ref Id, ref ConfigurationKey, ref ConfigurationKeyFieldType, ref ConfigurationKeyFromInputType, ref ConfigurationValue, ref ConfigurationValueType, ref ParentConfigurationKeyId);

            var items = this.context.ProjectConfigurationKeyAndValueUpdates.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueUpdate] @Id={0}, @ConfigurationKey={1}, @ConfigurationKeyFieldType={2}, @ConfigurationKeyFromInputType={3}, @ConfigurationValue={4}, @ConfigurationValueType={5}, @ParentConfigurationKeyId={6}", Id, ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueUpdatesDefaultParams(ref int? Id, ref string ConfigurationKey, ref string ConfigurationKeyFieldType, ref int? ConfigurationKeyFromInputType, ref string ConfigurationValue, ref int? ConfigurationValueType, ref int? ParentConfigurationKeyId);

        partial void OnProjectConfigurationKeyAndValueUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueUpdate> items);
    }
}
