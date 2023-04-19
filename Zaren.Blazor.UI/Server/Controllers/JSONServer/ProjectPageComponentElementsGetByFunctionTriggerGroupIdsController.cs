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
    public partial class ProjectPageComponentElementsGetByFunctionTriggerGroupIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByFunctionTriggerGroupIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByFunctionTriggerGroupIdsFunc(FunctionTriggerGroupId={FunctionTriggerGroupId})")]
        public IActionResult ProjectPageComponentElementsGetByFunctionTriggerGroupIdsFunc([FromODataUri] int? FunctionTriggerGroupId)
        {
            this.OnProjectPageComponentElementsGetByFunctionTriggerGroupIdsDefaultParams(ref FunctionTriggerGroupId);

            var items = this.context.ProjectPageComponentElementsGetByFunctionTriggerGroupIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByFunctionTriggerGroupId] @FunctionTriggerGroupId={0}", FunctionTriggerGroupId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByFunctionTriggerGroupIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByFunctionTriggerGroupIdsDefaultParams(ref int? FunctionTriggerGroupId);

        partial void OnProjectPageComponentElementsGetByFunctionTriggerGroupIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerGroupId> items);
    }
}
