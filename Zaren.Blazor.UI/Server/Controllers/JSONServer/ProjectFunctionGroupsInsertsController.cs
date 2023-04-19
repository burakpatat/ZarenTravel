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
    public partial class ProjectFunctionGroupsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsInsertsFunc(FunctionGroupName={FunctionGroupName},CallAfterFunctionsSuccessfullResponse={CallAfterFunctionsSuccessfullResponse},SoftWareLanguageId={SoftWareLanguageId},CurrencyId={CurrencyId},Price={Price},Commission={Commission})")]
        public IActionResult ProjectFunctionGroupsInsertsFunc([FromODataUri] string FunctionGroupName, [FromODataUri] int? CallAfterFunctionsSuccessfullResponse, [FromODataUri] int? SoftWareLanguageId, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Price, [FromODataUri] decimal? Commission)
        {
            this.OnProjectFunctionGroupsInsertsDefaultParams(ref FunctionGroupName, ref CallAfterFunctionsSuccessfullResponse, ref SoftWareLanguageId, ref CurrencyId, ref Price, ref Commission);

            var items = this.context.ProjectFunctionGroupsInserts.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsInsert] @FunctionGroupName={0}, @CallAfterFunctionsSuccessfullResponse={1}, @SoftWareLanguageId={2}, @CurrencyId={3}, @Price={4}, @Commission={5}", FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission).ToList().AsQueryable();

            this.OnProjectFunctionGroupsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsInsertsDefaultParams(ref string FunctionGroupName, ref int? CallAfterFunctionsSuccessfullResponse, ref int? SoftWareLanguageId, ref int? CurrencyId, ref decimal? Price, ref decimal? Commission);

        partial void OnProjectFunctionGroupsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsInsert> items);
    }
}
