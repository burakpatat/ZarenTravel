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
    public partial class ColorGroupsGetByGroupListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ColorGroupsGetByGroupListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ColorGroupsGetByGroupListsFunc(GroupList={GroupList})")]
        public IActionResult ColorGroupsGetByGroupListsFunc([FromODataUri] string GroupList)
        {
            this.OnColorGroupsGetByGroupListsDefaultParams(ref GroupList);

            var items = this.context.ColorGroupsGetByGroupLists.FromSqlRaw("EXEC [dbo].[ColorGroupsGetByGroupList] @GroupList={0}", GroupList).ToList().AsQueryable();

            this.OnColorGroupsGetByGroupListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnColorGroupsGetByGroupListsDefaultParams(ref string GroupList);

        partial void OnColorGroupsGetByGroupListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByGroupList> items);
    }
}
