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
    public partial class ProjectPageComponentElementsGetByHasAsyncsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByHasAsyncsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByHasAsyncsFunc(HasAsync={HasAsync})")]
        public IActionResult ProjectPageComponentElementsGetByHasAsyncsFunc([FromODataUri] bool? HasAsync)
        {
            this.OnProjectPageComponentElementsGetByHasAsyncsDefaultParams(ref HasAsync);

            var items = this.context.ProjectPageComponentElementsGetByHasAsyncs.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByHasAsync] @HasAsync={0}", HasAsync).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByHasAsyncsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByHasAsyncsDefaultParams(ref bool? HasAsync);

        partial void OnProjectPageComponentElementsGetByHasAsyncsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasAsync> items);
    }
}
