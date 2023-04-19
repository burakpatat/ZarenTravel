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
    public partial class ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsFunc(IfResponseIsSuccessCallThisComponentPartId={IfResponseIsSuccessCallThisComponentPartId})")]
        public IActionResult ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsFunc([FromODataUri] int? IfResponseIsSuccessCallThisComponentPartId)
        {
            this.OnProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsDefaultParams(ref IfResponseIsSuccessCallThisComponentPartId);

            var items = this.context.ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartId] @IfResponseIsSuccessCallThisComponentPartId={0}", IfResponseIsSuccessCallThisComponentPartId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsDefaultParams(ref int? IfResponseIsSuccessCallThisComponentPartId);

        partial void OnProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartId> items);
    }
}
