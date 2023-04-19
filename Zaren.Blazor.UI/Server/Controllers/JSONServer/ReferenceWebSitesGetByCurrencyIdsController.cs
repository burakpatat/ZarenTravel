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
    public partial class ReferenceWebSitesGetByCurrencyIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByCurrencyIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByCurrencyIdsFunc(CurrencyId={CurrencyId})")]
        public IActionResult ReferenceWebSitesGetByCurrencyIdsFunc([FromODataUri] int? CurrencyId)
        {
            this.OnReferenceWebSitesGetByCurrencyIdsDefaultParams(ref CurrencyId);

            var items = this.context.ReferenceWebSitesGetByCurrencyIds.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByCurrencyId] @CurrencyId={0}", CurrencyId).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByCurrencyIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByCurrencyIdsDefaultParams(ref int? CurrencyId);

        partial void OnReferenceWebSitesGetByCurrencyIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCurrencyId> items);
    }
}
