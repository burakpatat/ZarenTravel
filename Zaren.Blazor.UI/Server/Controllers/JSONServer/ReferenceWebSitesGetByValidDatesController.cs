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
    public partial class ReferenceWebSitesGetByValidDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByValidDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByValidDatesFunc(ValidDate={ValidDate})")]
        public IActionResult ReferenceWebSitesGetByValidDatesFunc([FromODataUri] string ValidDate)
        {
            this.OnReferenceWebSitesGetByValidDatesDefaultParams(ref ValidDate);

            var items = this.context.ReferenceWebSitesGetByValidDates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByValidDate] @ValidDate={0}", ValidDate).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByValidDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByValidDatesDefaultParams(ref string ValidDate);

        partial void OnReferenceWebSitesGetByValidDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByValidDate> items);
    }
}
