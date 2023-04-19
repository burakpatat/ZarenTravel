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
    public partial class ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersFunc(FunctionTriggerCallAfterSuccessfullTrigger={FunctionTriggerCallAfterSuccessfullTrigger})")]
        public IActionResult ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersFunc([FromODataUri] int? FunctionTriggerCallAfterSuccessfullTrigger)
        {
            this.OnProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersDefaultParams(ref FunctionTriggerCallAfterSuccessfullTrigger);

            var items = this.context.ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggers.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTrigger] @FunctionTriggerCallAfterSuccessfullTrigger={0}", FunctionTriggerCallAfterSuccessfullTrigger).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersDefaultParams(ref int? FunctionTriggerCallAfterSuccessfullTrigger);

        partial void OnProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTrigger> items);
    }
}
