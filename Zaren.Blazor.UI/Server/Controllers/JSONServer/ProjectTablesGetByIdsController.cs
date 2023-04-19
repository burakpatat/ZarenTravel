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
    public partial class ProjectTablesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectTablesGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectTablesGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectTablesGetByIds.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectTablesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectTablesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetById> items);
    }
}
