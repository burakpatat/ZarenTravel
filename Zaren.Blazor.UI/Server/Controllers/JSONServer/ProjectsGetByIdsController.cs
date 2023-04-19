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
    public partial class ProjectsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetById> items);
    }
}
