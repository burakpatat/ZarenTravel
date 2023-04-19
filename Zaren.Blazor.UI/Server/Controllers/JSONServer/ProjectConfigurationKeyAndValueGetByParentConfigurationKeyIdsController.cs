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
    public partial class ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsFunc(ParentConfigurationKeyId={ParentConfigurationKeyId})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsFunc([FromODataUri] int? ParentConfigurationKeyId)
        {
            this.OnProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsDefaultParams(ref ParentConfigurationKeyId);

            var items = this.context.ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIds.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByParentConfigurationKeyId] @ParentConfigurationKeyId={0}", ParentConfigurationKeyId).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsDefaultParams(ref int? ParentConfigurationKeyId);

        partial void OnProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByParentConfigurationKeyId> items);
    }
}
