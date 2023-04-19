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
    public partial class ProjectFunctionGroupsGetBySoftWareLanguageIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetBySoftWareLanguageIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetBySoftWareLanguageIdsFunc(SoftWareLanguageId={SoftWareLanguageId})")]
        public IActionResult ProjectFunctionGroupsGetBySoftWareLanguageIdsFunc([FromODataUri] int? SoftWareLanguageId)
        {
            this.OnProjectFunctionGroupsGetBySoftWareLanguageIdsDefaultParams(ref SoftWareLanguageId);

            var items = this.context.ProjectFunctionGroupsGetBySoftWareLanguageIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetBySoftWareLanguageId] @SoftWareLanguageId={0}", SoftWareLanguageId).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetBySoftWareLanguageIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetBySoftWareLanguageIdsDefaultParams(ref int? SoftWareLanguageId);

        partial void OnProjectFunctionGroupsGetBySoftWareLanguageIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetBySoftWareLanguageId> items);
    }
}
