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
    public partial class ProjectTableColumnsGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectTableColumnsGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectTableColumnsGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectTableColumnsGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectTableColumnsGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCurrencyId> items);
    }
}
