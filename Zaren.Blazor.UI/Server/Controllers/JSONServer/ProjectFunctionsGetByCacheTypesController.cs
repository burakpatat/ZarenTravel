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
    public partial class ProjectFunctionsGetByCacheTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCacheTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCacheTypesFunc(CacheType={CacheType})")]
        public IActionResult ProjectFunctionsGetByCacheTypesFunc([FromODataUri] int? CacheType)
        {
            this.OnProjectFunctionsGetByCacheTypesDefaultParams(ref CacheType);

            var items = this.context.ProjectFunctionsGetByCacheTypes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCacheType] @CacheType={0}", CacheType).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCacheTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCacheTypesDefaultParams(ref int? CacheType);

        partial void OnProjectFunctionsGetByCacheTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheType> items);
    }
}
