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
    public partial class ProjectPageComponentElementsGetByCacheTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCacheTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCacheTypesFunc(CacheType={CacheType})")]
        public IActionResult ProjectPageComponentElementsGetByCacheTypesFunc([FromODataUri] int? CacheType)
        {
            this.OnProjectPageComponentElementsGetByCacheTypesDefaultParams(ref CacheType);

            var items = this.context.ProjectPageComponentElementsGetByCacheTypes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCacheType] @CacheType={0}", CacheType).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCacheTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCacheTypesDefaultParams(ref int? CacheType);

        partial void OnProjectPageComponentElementsGetByCacheTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheType> items);
    }
}
