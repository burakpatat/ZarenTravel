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
    public partial class ProjectPageComponentElementsGetByHasCacheMethodsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByHasCacheMethodsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByHasCacheMethodsFunc(HasCacheMethod={HasCacheMethod})")]
        public IActionResult ProjectPageComponentElementsGetByHasCacheMethodsFunc([FromODataUri] bool? HasCacheMethod)
        {
            this.OnProjectPageComponentElementsGetByHasCacheMethodsDefaultParams(ref HasCacheMethod);

            var items = this.context.ProjectPageComponentElementsGetByHasCacheMethods.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByHasCacheMethod] @HasCacheMethod={0}", HasCacheMethod).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByHasCacheMethodsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByHasCacheMethodsDefaultParams(ref bool? HasCacheMethod);

        partial void OnProjectPageComponentElementsGetByHasCacheMethodsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCacheMethod> items);
    }
}
