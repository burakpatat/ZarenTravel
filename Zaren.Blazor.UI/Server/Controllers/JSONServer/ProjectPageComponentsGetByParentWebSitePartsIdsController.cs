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
    public partial class ProjectPageComponentsGetByParentWebSitePartsIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByParentWebSitePartsIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByParentWebSitePartsIdsFunc(ParentWebSitePartsId={ParentWebSitePartsId})")]
        public IActionResult ProjectPageComponentsGetByParentWebSitePartsIdsFunc([FromODataUri] int? ParentWebSitePartsId)
        {
            this.OnProjectPageComponentsGetByParentWebSitePartsIdsDefaultParams(ref ParentWebSitePartsId);

            var items = this.context.ProjectPageComponentsGetByParentWebSitePartsIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByParentWebSitePartsId] @ParentWebSitePartsId={0}", ParentWebSitePartsId).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByParentWebSitePartsIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByParentWebSitePartsIdsDefaultParams(ref int? ParentWebSitePartsId);

        partial void OnProjectPageComponentsGetByParentWebSitePartsIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByParentWebSitePartsId> items);
    }
}
