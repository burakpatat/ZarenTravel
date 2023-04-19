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
    public partial class ProjectConfigurationsGetByCreatedByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByCreatedByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByCreatedByIdsFunc(CreatedById={CreatedById})")]
        public IActionResult ProjectConfigurationsGetByCreatedByIdsFunc([FromODataUri] int? CreatedById)
        {
            this.OnProjectConfigurationsGetByCreatedByIdsDefaultParams(ref CreatedById);

            var items = this.context.ProjectConfigurationsGetByCreatedByIds.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByCreatedById] @CreatedById={0}", CreatedById).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByCreatedByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByCreatedByIdsDefaultParams(ref int? CreatedById);

        partial void OnProjectConfigurationsGetByCreatedByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCreatedById> items);
    }
}
