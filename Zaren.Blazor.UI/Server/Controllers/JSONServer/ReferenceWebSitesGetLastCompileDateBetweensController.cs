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
    public partial class ReferenceWebSitesGetLastCompileDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetLastCompileDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetLastCompileDateBetweensFunc(LastCompileDateStart={LastCompileDateStart},LastCompileDateEnd={LastCompileDateEnd})")]
        public IActionResult ReferenceWebSitesGetLastCompileDateBetweensFunc([FromODataUri] string LastCompileDateStart, [FromODataUri] string LastCompileDateEnd)
        {
            this.OnReferenceWebSitesGetLastCompileDateBetweensDefaultParams(ref LastCompileDateStart, ref LastCompileDateEnd);

            var items = this.context.ReferenceWebSitesGetLastCompileDateBetweens.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetLastCompileDateBetween] @LastCompileDateStart={0}, @LastCompileDateEnd={1}", LastCompileDateStart, LastCompileDateEnd).ToList().AsQueryable();

            this.OnReferenceWebSitesGetLastCompileDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetLastCompileDateBetweensDefaultParams(ref string LastCompileDateStart, ref string LastCompileDateEnd);

        partial void OnReferenceWebSitesGetLastCompileDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetLastCompileDateBetween> items);
    }
}
