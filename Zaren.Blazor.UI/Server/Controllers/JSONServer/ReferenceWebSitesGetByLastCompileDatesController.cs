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
    public partial class ReferenceWebSitesGetByLastCompileDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByLastCompileDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByLastCompileDatesFunc(LastCompileDate={LastCompileDate})")]
        public IActionResult ReferenceWebSitesGetByLastCompileDatesFunc([FromODataUri] string LastCompileDate)
        {
            this.OnReferenceWebSitesGetByLastCompileDatesDefaultParams(ref LastCompileDate);

            var items = this.context.ReferenceWebSitesGetByLastCompileDates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByLastCompileDate] @LastCompileDate={0}", LastCompileDate).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByLastCompileDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByLastCompileDatesDefaultParams(ref string LastCompileDate);

        partial void OnReferenceWebSitesGetByLastCompileDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLastCompileDate> items);
    }
}
