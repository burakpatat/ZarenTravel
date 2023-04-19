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
    public partial class ProjectFunctionsGetByNameSpaceListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByNameSpaceListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByNameSpaceListsFunc(NameSpaceList={NameSpaceList})")]
        public IActionResult ProjectFunctionsGetByNameSpaceListsFunc([FromODataUri] string NameSpaceList)
        {
            this.OnProjectFunctionsGetByNameSpaceListsDefaultParams(ref NameSpaceList);

            var items = this.context.ProjectFunctionsGetByNameSpaceLists.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByNameSpaceList] @NameSpaceList={0}", NameSpaceList).ToList().AsQueryable();

            this.OnProjectFunctionsGetByNameSpaceListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByNameSpaceListsDefaultParams(ref string NameSpaceList);

        partial void OnProjectFunctionsGetByNameSpaceListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByNameSpaceList> items);
    }
}
