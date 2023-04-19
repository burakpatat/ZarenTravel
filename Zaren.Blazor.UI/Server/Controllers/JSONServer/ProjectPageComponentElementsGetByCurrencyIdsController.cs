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
    public partial class ProjectPageComponentElementsGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectPageComponentElementsGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectPageComponentElementsGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectPageComponentElementsGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectPageComponentElementsGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCurrencyId> items);
    }
}
