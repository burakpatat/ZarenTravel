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
    public partial class ProjectTablesGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectTablesGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectTablesGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectTablesGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectTablesGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectTablesGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCurrencyId> items);
    }
}
