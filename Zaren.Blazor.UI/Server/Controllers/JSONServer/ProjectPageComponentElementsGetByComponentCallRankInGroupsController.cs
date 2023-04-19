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
    public partial class ProjectPageComponentElementsGetByComponentCallRankInGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByComponentCallRankInGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByComponentCallRankInGroupsFunc(ComponentCallRankInGroup={ComponentCallRankInGroup})")]
        public IActionResult ProjectPageComponentElementsGetByComponentCallRankInGroupsFunc([FromODataUri] int? ComponentCallRankInGroup)
        {
            this.OnProjectPageComponentElementsGetByComponentCallRankInGroupsDefaultParams(ref ComponentCallRankInGroup);

            var items = this.context.ProjectPageComponentElementsGetByComponentCallRankInGroups.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByComponentCallRankInGroup] @ComponentCallRankInGroup={0}", ComponentCallRankInGroup).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByComponentCallRankInGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByComponentCallRankInGroupsDefaultParams(ref int? ComponentCallRankInGroup);

        partial void OnProjectPageComponentElementsGetByComponentCallRankInGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentCallRankInGroup> items);
    }
}
