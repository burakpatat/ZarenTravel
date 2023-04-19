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
    public partial class ProjectPageComponentElementsGetByNameSpaceListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByNameSpaceListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByNameSpaceListsFunc(NameSpaceList={NameSpaceList})")]
        public IActionResult ProjectPageComponentElementsGetByNameSpaceListsFunc([FromODataUri] string NameSpaceList)
        {
            this.OnProjectPageComponentElementsGetByNameSpaceListsDefaultParams(ref NameSpaceList);

            var items = this.context.ProjectPageComponentElementsGetByNameSpaceLists.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByNameSpaceList] @NameSpaceList={0}", NameSpaceList).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByNameSpaceListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByNameSpaceListsDefaultParams(ref string NameSpaceList);

        partial void OnProjectPageComponentElementsGetByNameSpaceListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByNameSpaceList> items);
    }
}
