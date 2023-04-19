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
    public partial class DesignschemesgetbycolorsColor5IsdarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor5IsdarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor5IsdarksFunc(colors_color5_isDark={colors_color5_isDark})")]
        public IActionResult DesignschemesgetbycolorsColor5IsdarksFunc([FromODataUri] string colors_color5_isDark)
        {
            this.OnDesignschemesgetbycolorsColor5IsdarksDefaultParams(ref colors_color5_isDark);

            var items = this.context.DesignschemesgetbycolorsColor5Isdarks.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color5_isDark] @colors_color5_isDark={0}", colors_color5_isDark).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor5IsdarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor5IsdarksDefaultParams(ref string colors_color5_isDark);

        partial void OnDesignschemesgetbycolorsColor5IsdarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Isdark> items);
    }
}
