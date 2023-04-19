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
    public partial class ProjectPageComponentElementsGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetAllsFunc()")]
        public IActionResult ProjectPageComponentElementsGetAllsFunc()
        {
            this.OnProjectPageComponentElementsGetAllsDefaultParams();

            var items = this.context.ProjectPageComponentElementsGetAlls.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetAll] ").ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetAllsDefaultParams();

        partial void OnProjectPageComponentElementsGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetAll> items);
    }
}
