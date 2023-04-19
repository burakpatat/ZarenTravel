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
    public partial class ProjectsGetByEnumListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByEnumListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByEnumListsFunc(EnumLists={EnumLists})")]
        public IActionResult ProjectsGetByEnumListsFunc([FromODataUri] object EnumLists)
        {
            this.OnProjectsGetByEnumListsDefaultParams(ref EnumLists);

            var items = this.context.ProjectsGetByEnumLists.FromSqlRaw("EXEC [dbo].[ProjectsGetByEnumLists] @EnumLists={0}", EnumLists).ToList().AsQueryable();

            this.OnProjectsGetByEnumListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByEnumListsDefaultParams(ref object EnumLists);

        partial void OnProjectsGetByEnumListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByEnumList> items);
    }
}
