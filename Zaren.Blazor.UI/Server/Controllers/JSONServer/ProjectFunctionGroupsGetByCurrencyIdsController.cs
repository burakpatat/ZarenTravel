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
    public partial class ProjectFunctionGroupsGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectFunctionGroupsGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectFunctionGroupsGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectFunctionGroupsGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectFunctionGroupsGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCurrencyId> items);
    }
}
