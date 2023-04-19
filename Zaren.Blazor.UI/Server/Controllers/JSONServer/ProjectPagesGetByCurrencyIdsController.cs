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
    public partial class ProjectPagesGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ProjectPagesGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnProjectPagesGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ProjectPagesGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnProjectPagesGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnProjectPagesGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCurrencyId> items);
    }
}
