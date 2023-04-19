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
    public partial class DesignschemesgetbycolorsColor4IsdarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor4IsdarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor4IsdarksFunc(colors_color4_isDark={colors_color4_isDark})")]
        public IActionResult DesignschemesgetbycolorsColor4IsdarksFunc([FromODataUri] string colors_color4_isDark)
        {
            this.OnDesignschemesgetbycolorsColor4IsdarksDefaultParams(ref colors_color4_isDark);

            var items = this.context.DesignschemesgetbycolorsColor4Isdarks.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color4_isDark] @colors_color4_isDark={0}", colors_color4_isDark).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor4IsdarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor4IsdarksDefaultParams(ref string colors_color4_isDark);

        partial void OnDesignschemesgetbycolorsColor4IsdarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Isdark> items);
    }
}
