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
    public partial class ProjectConfigurationKeyAndValueGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationKeyAndValueGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationKeyAndValueGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectConfigurationKeyAndValueGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectConfigurationKeyAndValueGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectConfigurationKeyAndValueGetByIds.FromSqlRaw("EXEC [dbo].[ProjectConfigurationKeyAndValueGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectConfigurationKeyAndValueGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationKeyAndValueGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectConfigurationKeyAndValueGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetById> items);
    }
}
