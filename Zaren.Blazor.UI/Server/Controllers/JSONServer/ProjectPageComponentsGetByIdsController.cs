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
    public partial class ProjectPageComponentsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectPageComponentsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectPageComponentsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectPageComponentsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectPageComponentsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetById> items);
    }
}
