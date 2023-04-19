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
    public partial class ReferenceWebSitesGetByModifyDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByModifyDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByModifyDatesFunc(ModifyDate={ModifyDate})")]
        public IActionResult ReferenceWebSitesGetByModifyDatesFunc([FromODataUri] string ModifyDate)
        {
            this.OnReferenceWebSitesGetByModifyDatesDefaultParams(ref ModifyDate);

            var items = this.context.ReferenceWebSitesGetByModifyDates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByModifyDate] @ModifyDate={0}", ModifyDate).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByModifyDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByModifyDatesDefaultParams(ref string ModifyDate);

        partial void OnReferenceWebSitesGetByModifyDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByModifyDate> items);
    }
}
