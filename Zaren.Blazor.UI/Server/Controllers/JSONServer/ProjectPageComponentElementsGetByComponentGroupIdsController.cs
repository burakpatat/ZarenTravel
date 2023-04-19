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
    public partial class ProjectPageComponentElementsGetByComponentGroupIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByComponentGroupIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByComponentGroupIdsFunc(ComponentGroupId={ComponentGroupId})")]
        public IActionResult ProjectPageComponentElementsGetByComponentGroupIdsFunc([FromODataUri] int? ComponentGroupId)
        {
            this.OnProjectPageComponentElementsGetByComponentGroupIdsDefaultParams(ref ComponentGroupId);

            var items = this.context.ProjectPageComponentElementsGetByComponentGroupIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByComponentGroupId] @ComponentGroupId={0}", ComponentGroupId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByComponentGroupIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByComponentGroupIdsDefaultParams(ref int? ComponentGroupId);

        partial void OnProjectPageComponentElementsGetByComponentGroupIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentGroupId> items);
    }
}
