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
    public partial class ProjectPageComponentsGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectPageComponentsGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectPageComponentsGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectPageComponentsGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectPageComponentsGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCurrencyId> items);
    }
}
