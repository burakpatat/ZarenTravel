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
    public partial class ProjectPageComponentElementsGetByUserIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByUserIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByUserIdsFunc(UserId={UserId})")]
        public IActionResult ProjectPageComponentElementsGetByUserIdsFunc([FromODataUri] int? UserId)
        {
            this.OnProjectPageComponentElementsGetByUserIdsDefaultParams(ref UserId);

            var items = this.context.ProjectPageComponentElementsGetByUserIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByUserId] @UserId={0}", UserId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByUserIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByUserIdsDefaultParams(ref int? UserId);

        partial void OnProjectPageComponentElementsGetByUserIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserId> items);
    }
}
