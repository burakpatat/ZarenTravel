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
    public partial class ProjectPageComponentElementsGetByComponentIsParentInGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByComponentIsParentInGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByComponentIsParentInGroupsFunc(ComponentIsParentInGroup={ComponentIsParentInGroup})")]
        public IActionResult ProjectPageComponentElementsGetByComponentIsParentInGroupsFunc([FromODataUri] bool? ComponentIsParentInGroup)
        {
            this.OnProjectPageComponentElementsGetByComponentIsParentInGroupsDefaultParams(ref ComponentIsParentInGroup);

            var items = this.context.ProjectPageComponentElementsGetByComponentIsParentInGroups.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByComponentIsParentInGroup] @ComponentIsParentInGroup={0}", ComponentIsParentInGroup).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByComponentIsParentInGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByComponentIsParentInGroupsDefaultParams(ref bool? ComponentIsParentInGroup);

        partial void OnProjectPageComponentElementsGetByComponentIsParentInGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentIsParentInGroup> items);
    }
}
