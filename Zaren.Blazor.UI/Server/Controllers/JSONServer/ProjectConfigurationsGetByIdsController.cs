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
    public partial class ProjectConfigurationsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectConfigurationsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectConfigurationsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectConfigurationsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectConfigurationsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetById> items);
    }
}
