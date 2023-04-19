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
    public partial class ReferenceWebSitesGetByProjectCategoryIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByProjectCategoryIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByProjectCategoryIdsFunc(ProjectCategoryId={ProjectCategoryId})")]
        public IActionResult ReferenceWebSitesGetByProjectCategoryIdsFunc([FromODataUri] int? ProjectCategoryId)
        {
            this.OnReferenceWebSitesGetByProjectCategoryIdsDefaultParams(ref ProjectCategoryId);

            var items = this.context.ReferenceWebSitesGetByProjectCategoryIds.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByProjectCategoryId] @ProjectCategoryId={0}", ProjectCategoryId).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByProjectCategoryIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByProjectCategoryIdsDefaultParams(ref int? ProjectCategoryId);

        partial void OnReferenceWebSitesGetByProjectCategoryIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByProjectCategoryId> items);
    }
}
