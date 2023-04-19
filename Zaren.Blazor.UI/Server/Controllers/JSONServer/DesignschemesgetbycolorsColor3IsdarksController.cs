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
    public partial class DesignschemesgetbycolorsColor3IsdarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor3IsdarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor3IsdarksFunc(colors_color3_isDark={colors_color3_isDark})")]
        public IActionResult DesignschemesgetbycolorsColor3IsdarksFunc([FromODataUri] string colors_color3_isDark)
        {
            this.OnDesignschemesgetbycolorsColor3IsdarksDefaultParams(ref colors_color3_isDark);

            var items = this.context.DesignschemesgetbycolorsColor3Isdarks.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color3_isDark] @colors_color3_isDark={0}", colors_color3_isDark).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor3IsdarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor3IsdarksDefaultParams(ref string colors_color3_isDark);

        partial void OnDesignschemesgetbycolorsColor3IsdarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Isdark> items);
    }
}
