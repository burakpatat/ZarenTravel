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
    public partial class ProjectFunctionGroupsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsUpdatesFunc(Id={Id},FunctionGroupName={FunctionGroupName},CallAfterFunctionsSuccessfullResponse={CallAfterFunctionsSuccessfullResponse},SoftWareLanguageId={SoftWareLanguageId},CurrencyId={CurrencyId},Price={Price},Commission={Commission})")]
        public IActionResult ProjectFunctionGroupsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string FunctionGroupName, [FromODataUri] int? CallAfterFunctionsSuccessfullResponse, [FromODataUri] int? SoftWareLanguageId, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Price, [FromODataUri] decimal? Commission)
        {
            this.OnProjectFunctionGroupsUpdatesDefaultParams(ref Id, ref FunctionGroupName, ref CallAfterFunctionsSuccessfullResponse, ref SoftWareLanguageId, ref CurrencyId, ref Price, ref Commission);

            var items = this.context.ProjectFunctionGroupsUpdates.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsUpdate] @Id={0}, @FunctionGroupName={1}, @CallAfterFunctionsSuccessfullResponse={2}, @SoftWareLanguageId={3}, @CurrencyId={4}, @Price={5}, @Commission={6}", Id, FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission).ToList().AsQueryable();

            this.OnProjectFunctionGroupsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsUpdatesDefaultParams(ref int? Id, ref string FunctionGroupName, ref int? CallAfterFunctionsSuccessfullResponse, ref int? SoftWareLanguageId, ref int? CurrencyId, ref decimal? Price, ref decimal? Commission);

        partial void OnProjectFunctionGroupsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsUpdate> items);
    }
}
